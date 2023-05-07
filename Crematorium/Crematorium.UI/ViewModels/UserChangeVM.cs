using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Crematorium.Application.Abstractions;
using Crematorium.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
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
        private Role selectedRole;

        [ObservableProperty]
        [Required]
        private User user;

        public void SetUser(int userId)
        {
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
        public void AddUser()
        {
            if (User == null)
                throw new ArgumentNullException("User not initialized");

            if (Name == string.Empty || Surname == string.Empty ||
                NumPassport == string.Empty || MailAdress == string.Empty)
                throw new Exception("Not initialize data");

            if (Name != User.Name && _userService.IsValided(Name, NumPassport).Result)
            {
                throw new Exception("Такой пользователь уже существует");
            }

            User.Name = this.Name;
            User.Surname = this.Surname;
            User.NumPassport = this.NumPassport;
            User.UserRole = this.SelectedRole;
            User.MailAdress = this.MailAdress;

            if(_isNewUser)
            {
                _userService.AddAsync(User);
            }
            else
            {
                _userService.UpdateAsync(User);
            }
        }
    }
}
