using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Crematorium.Application.Abstractions;
using Crematorium.UI.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Crematorium.UI.ViewModels
{
    public partial class LogAndRegVM : ObservableValidator //ObservableObject     
    {
        private IUserService _userService;
        public LogAndRegVM(IUserService userService) 
        {
            _userService = userService;
        }

        [ObservableProperty]
        [Required]
        private string inputName = string.Empty;

        [ObservableProperty]
        [Required]
        private string inputNumPassport = string.Empty;
 

        [RelayCommand]
        public void ValidesUser()
        {
            bool validedUser = _userService.IsValided(inputName, inputNumPassport).Result;

            if (validedUser)
            {
                MessageBox.Show("Успешная авторизация!");
            }
            else
            {
                MessageBox.Show("Такого аккаунта нет:(");
            }

        }
    }
}
