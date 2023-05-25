using Crematorium.Domain.Entities;
using Crematorium.UI.Fabrics;
using Crematorium.UI.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Crematorium.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChangeUserPage.xaml
    /// </summary>
    public partial class ChangeUserPage : Window
    {
        private UserChangeVM _userChangeVM;
        private bool isRegistration;
        public ChangeUserPage(UserChangeVM VM)
        {
            _userChangeVM = VM;
            InitializeComponent();
            RoleComboBox.ItemsSource = Enum.GetValues(typeof(Role)).Cast<Role>().ToList();
            DataContext = _userChangeVM;
        }

        public void InitializeUser(int Id, UserChangeOperation op)
        {
            _userChangeVM.SetUser(Id, op);
        }


        private void Window_MousDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            //this.Close();
            this.Hide();
        }

        private async void AddOrUpdateUser(object sender, RoutedEventArgs e)
        {
            try
            {
                await _userChangeVM.DoUserOperation();
                this.Hide();
            }
            catch (Exception ex)
            {
                var er = ServicesFabric.GetErrorPage(ex.Message);
                er.ShowDialog();
            }
        }
    }
}
