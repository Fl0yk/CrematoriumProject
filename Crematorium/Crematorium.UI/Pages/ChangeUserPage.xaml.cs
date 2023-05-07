using Crematorium.Domain.Entities;
using Crematorium.UI.ViewModels;
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
        public ChangeUserPage(UserChangeVM VM)
        {
            _userChangeVM = VM;
            InitializeComponent();
            RoleComboBox.ItemsSource = Enum.GetValues(typeof(Role)).Cast<Role>().ToList();
            DataContext = _userChangeVM;
        }

        public void InitializeUser(int Id)
        {
            _userChangeVM.SetUser(Id);
        }

        private void OperationBtn(object sender, RoutedEventArgs e)
        {

        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
