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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Crematorium.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowMenu(object sender, RoutedEventArgs e)
        {
            GridContent.Opacity = 0.5;
        }

        private void HideMenu(object sender, RoutedEventArgs e)
        {
            GridContent.Opacity = 1;
        }

        private void GridContent_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BtnShowHide.IsChecked = false;
        }
    }
}
