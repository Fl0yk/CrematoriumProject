using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Crematorium.Application.Abstractions;
using Crematorium.Application.Validators;
using Crematorium.Domain.Entities;
using Crematorium.UI.Fabrics;
using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Crematorium.UI.ViewModels
{
    public partial class UserChangeVM : ObservableValidator
    {
        private IUserService _userService;
        private bool _isNewUser;
        public UserChangeVM(IUserService userService)
        {
            _userService = userService;
            SelectedRole = Role.NoName;
        }
        [ObservableProperty]
        private UserChangeOperation operation;

        [ObservableProperty]
        private bool isRegistration;

        [ObservableProperty]
        private Role selectedRole;

        [ObservableProperty]
        [Required]
        private User user;

        public void SetUser(int userId, UserChangeOperation op)
        {
            //IsRegistration = isRegUser;
            operation = op;
            User = _userService.GetByIdAsync(userId).Result;

            if (User is null)
            {
                User = new User();
                _isNewUser = true;
            }
            else
            {
                _isNewUser = false;
            }
            this.Name = User.Name;
            this.Surname = User.Surname;
            //this.NumPassport = User.NumPassport;
            this.SelectedRole = User.UserRole;
            this.MailAdress = User.MailAdress;
        }

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string surname;

        [ObservableProperty]
        private string numPassport;

        [ObservableProperty]
        private string mailAdress;

        [RelayCommand]
        public async void AddUser()
        {
            if (User is null)
                throw new ArgumentNullException("User not initialized");

            if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name) ||
                string.IsNullOrEmpty(Surname) || string.IsNullOrWhiteSpace(Surname) ||
                string.IsNullOrEmpty(MailAdress) || string.IsNullOrWhiteSpace(MailAdress))
            {
                var er = ServicesFabric.GetErrorPage("Что-то не заполнили");
                er.ShowDialog();
                return;
            }

            if (Name != User.Name && _userService.IsValided(Name, NumPassport).Result)
            {
                var er = ServicesFabric.GetErrorPage("Такой ползователь уже существует");
                er.ShowDialog();
                return;
            }

            User.Name = this.Name;
            User.Surname = this.Surname;
            User.NumPassport = this.NumPassport;
            User.MailAdress = this.MailAdress;
            if(IsRegistration)
            {
                User.UserRole = Role.Customer;
            }
            else
            {
                User.UserRole = this.SelectedRole;
            }

            if(_isNewUser)
            {
                //User.Id = 0;
                await _userService.AddAsync(User);
            }
            else
            {
                //Админ изменяет любого пользователя(у него не будет доступа к номеру паспорта)
                if (ServicesFabric.CurrentUser!.UserRole == Role.Admin && ServicesFabric.CurrentUser! != User)
                {
                    await _userService.UpdateAsync(User);
                }
                //Пользователь изменяет свой аккаунт, введенный номер паспорта совпадает с изначальным
                else if (ServicesFabric.CurrentUser! == User && NumPassportMatch())
                {
                    await _userService.UpdateAsync(User);
                }
                //Введенный номер не совпадает с изначальным, выдаем ошибку о неверном номере
                else
                {

                }
            }

            if(IsRegistration)
            {
                ServicesFabric.CurrentUser = this.User;
            }
        }

        public async Task DoUserOperation()
        {
            if (User is null)
                throw new ArgumentNullException("User not initialized");

            UserValidator validations = new UserValidator();

            switch (operation)
            {
                case UserChangeOperation.UserRegistration:
                    //CheckInputValue();
                    User.NumPassport = this.NumPassport;
                    InitializeValue(true);
                    validations.ValidateAndThrow(User);
                    await _userService.AddAsync(User);
                    ServicesFabric.CurrentUser = this.User;
                    break;

                case UserChangeOperation.UserUpdate:
                    NumPassportMatch();
                    InitializeValue(true);
                    validations.ValidateAndThrow(User);
                    await _userService.UpdateAsync(User);
                    break;

                case UserChangeOperation.AdminAdd:
                    //CheckInputValue();
                    User.NumPassport = this.NumPassport;
                    InitializeValue(false);
                    validations.ValidateAndThrow(User);
                    await _userService.AddAsync(User);
                    break;

                case UserChangeOperation.AdminUpdate:
                    InitializeValue(true);
                    validations.ValidateAndThrow(User);
                    await _userService.UpdateAsync(User);
                    break;

                default:
                    throw new ArgumentException("Несуществующая операция");
            }
        }

        private bool CheckInputValue()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name) ||
                string.IsNullOrEmpty(Surname) || string.IsNullOrWhiteSpace(Surname) ||
                string.IsNullOrEmpty(MailAdress) || string.IsNullOrWhiteSpace(MailAdress))
            {
                //var er = ServicesFabric.GetErrorPage("Что-то не заполнили");
                //er.ShowDialog();
                //return false;
                throw new Exception("Что-то не заполнили");
            }

            if (Name != User.Name && _userService.IsValided(Name, NumPassport).Result)
            {
                //var er = ServicesFabric.GetErrorPage("Такой ползователь уже существует");
                //er.ShowDialog();
                //return false;
                throw new Exception("Такой пользователь уже существует");
            }

            return true;
        }

        private void InitializeValue(bool isUserRegistration)
        {
            User.Name = this.Name;
            User.Surname = this.Surname;
            //User.NumPassport = this.NumPassport;
            User.MailAdress = this.MailAdress;
            if (isUserRegistration)
            {
                User.UserRole = Role.Customer;
            }
            else
            {
                User.UserRole = this.SelectedRole;
            }
        }

        /// <summary>
        /// Проверяет совпадение изначального номера паспорта с введеным для подтверждения изменений
        /// </summary>
        private bool NumPassportMatch()
        {
            if (ServicesFabric.CurrentUser!.NumPassport != NumPassport)
                throw new Exception("Введенный номер паспорта не совпадает с номером пользователя");

            return true;
        }
    }

    public enum UserChangeOperation
    {
        UserRegistration,  //Вводятся все поля, валидация паспорта и почты, проверка на существование такого пользователя

        UserUpdate, //Заполнются полученными данными все поля, кроме паспорта.
                    //Валидация почты, проверка на совпадение паспорта, проверка на существование

        AdminAdd,   // Вводятся все данные, выбор роли, валидация почты и паспорта

        AdminUpdate // Не видно номера паспорта, валидация почты, выбор роли
    }

}
