using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Crematorium.Application.Abstractions;
using Crematorium.UI.Fabrics;
using Crematorium.UI.Pages;

namespace Crematorium.UI.ViewModels
{
    public partial class LoginVM : ObservableValidator
    {
        private IUserService _userService;
        public LoginVM(IUserService userService) 
        {
            _userService = userService;
        }

        [ObservableProperty]
        private string inputName;

        [ObservableProperty]
        private string inputNumPassport;

        [RelayCommand]
        public void LoginUser()
        {
            if (string.IsNullOrEmpty(InputName) ||
                string.IsNullOrEmpty(InputNumPassport))
            {
                throw new System.Exception("Что-то не заполнили");
            }

            bool validedUser = _userService.IsValided(InputName, InputNumPassport).Result;
            if (validedUser)
            {
                ServicesFabric.CurrentUser = _userService
                    .FirstOrDefaultAsync(u => u.NumPassport == InputNumPassport && u.Name == InputName)
                    .Result;
            }
            else
            {
                //throw new System.Exception("Такого пользователя нет");
                ServicesFabric.CurrentUser = null;
            }
        }

        [RelayCommand]
        public void RegistrationUser()
        {
            var userChange = (ChangeUserPage)ServicesFabric.GetPage(typeof(ChangeUserPage));
            userChange.InitializeUser(-1, true);
            userChange.OpBtnName.Text = "Registration";
            userChange.ShowDialog();
        }
    }
}
