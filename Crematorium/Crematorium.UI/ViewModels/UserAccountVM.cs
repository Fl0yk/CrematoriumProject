using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Crematorium.Domain.Entities;
using Crematorium.UI.Fabrics;
using Crematorium.UI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crematorium.UI.ViewModels
{
    public partial class UserAccountVM : ObservableValidator
    {
        [ObservableProperty]
        private User curUser;

        public UserAccountVM()
        {
            CurUser = ServicesFabric.CurrentUser!;
        }


        [RelayCommand]
        public void UpdateUser()
        {
            var userChange = (ChangeUserPage)ServicesFabric.GetPage(typeof(ChangeUserPage));
            userChange.InitializeUser( CurUser.Id, UserChangeOperation.UserUpdate);
            userChange.OpBtnName.Text = "Update";
            userChange.ShowDialog();
        }
    }
}
