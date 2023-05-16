using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Crematorium.Application.Abstractions;
using Crematorium.Domain.Entities;
using Crematorium.UI.Fabrics;
using Crematorium.UI.Pages;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Crematorium.UI.ViewModels
{
    public partial class UsersVM : ObservableValidator
    {
        private IUserService _userService;

        public UsersVM(IUserService userService)
        {
            _userService = userService;
            Users = new ObservableCollection<User>( _userService.GetAllAsync().Result);
            
        }

        [ObservableProperty]
        [MaxLength(20)]
        private string inputFindName;

        public ObservableCollection<User> Users { get; set; }

        [RelayCommand]
        public void FindUsers()
        {
            Users.Clear();
            if (inputFindName is null || inputFindName == string.Empty)
            {
                UpdateUsersCollection();
                return;
            }

            foreach (User user in _userService.FindByName(inputFindName).Result) 
            {
                Users.Add(user);
            }
        }

        [RelayCommand]
        public void AddUser()
        {
            var userChange = (ChangeUserPage)PagesFabric.GetPage(typeof(ChangeUserPage));
            userChange.InitializeUser(-1);
            userChange.OpBtnName.Text = "Registration";
            userChange.ShowDialog();
            UpdateUsersCollection();
        }

        [ObservableProperty]
        private User selectedUser;

        [RelayCommand]
        public void UpdateUser()
        {
            if (SelectedUser is null)
                return;

            var userChange = (ChangeUserPage)PagesFabric.GetPage(typeof(ChangeUserPage));
            userChange.InitializeUser(SelectedUser.Id);
            userChange.OpBtnName.Text = "Update";
            userChange.ShowDialog();
            UpdateUsersCollection();
        }

        [RelayCommand]
        public void DeleteUser()
        {
            if (SelectedUser is null || SelectedUser.Name == "Admin")
                return;

            _userService.DeleteAsync(SelectedUser.Id);
            UpdateUsersCollection();
        }

        private void UpdateUsersCollection()
        {
            Users.Clear();
            foreach (User user in _userService.GetAllAsync().Result)
            {
                Users.Add(user);
            }
        }
    }
}
