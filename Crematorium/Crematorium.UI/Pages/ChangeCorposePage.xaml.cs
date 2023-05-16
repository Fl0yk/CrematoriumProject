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
    /// Логика взаимодействия для ChangeCorposePage.xaml
    /// </summary>
    public partial class ChangeCorposePage : Window
    {
        private ChangeCorposeVM _urnVM;
        public ChangeCorposePage(ChangeCorposeVM VM)
        {
            _urnVM = VM;
            InitializeComponent();
            DataContext = _urnVM;
        }

        public void InitializeCorpose(int Id)
        {
            _urnVM.SetCorpose(Id);
        }

        public void InitializeCorpose(ref Corpose corpose)
        {
            _urnVM.SetCorpose(ref corpose);
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
            //Close();
            Hide();
        }
    }
}
