using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Crematorium.Application.Abstractions;
using Crematorium.Domain.Entities;
using Crematorium.UI.Fabrics;
using System;
using System.ComponentModel.DataAnnotations;

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
        private bool isRegistration;

        [ObservableProperty]
        private Role selectedRole;

        [ObservableProperty]
        [Required]
        private User user;

        public void SetUser(int userId, bool isRegUser)
        {
            IsRegistration = isRegUser;
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
            this.NumPassport = User.NumPassport;
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

            if (Name == string.Empty || Name is null ||
                Surname == string.Empty || Surname is null ||
                NumPassport == string.Empty || NumPassport is null ||
                MailAdress == string.Empty || MailAdress is null)
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
                await _userService.UpdateAsync(User);
            }

            if(IsRegistration)
            {
                ServicesFabric.CurrentUser = this.User;
            }
        }
    }
}
