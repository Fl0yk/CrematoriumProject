using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Crematorium.Domain.Entities;
using Crematorium.UI.Fabrics;
using Crematorium.UI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Crematorium.UI.ViewModels
{
    public partial class MainWindowVM : ObservableValidator
    {
        public MainWindowVM()
        {
            CurUser = ServicesFabric.CurrentUser;
        }

        [ObservableProperty]
        private User? curUser;

        [ObservableProperty]
        private string loginBtn = "My Account";

        public void LoginUser()
        {
            var loginPage = (LoginPage)ServicesFabric.GetPage(typeof(LoginPage));
            loginPage.ShowDialog();
            CurUser = ServicesFabric.CurrentUser;
            if (ServicesFabric.CurrentUser is not null)
            {
                LoginBtn = CurUser!.Name;
            }
            else
            {
                LoginBtn = "My Account";
            }
        }
    }
}
