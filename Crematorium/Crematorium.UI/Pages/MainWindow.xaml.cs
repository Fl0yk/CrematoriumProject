using Crematorium.UI.Fabrics;
using Crematorium.UI.Pages;
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

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Minimize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void UsersContent(object sender, RoutedEventArgs e)
        {
            DataContext = PagesFabric.GetPage(typeof(UsersPage));
        }

        private void UrnsContent(object sender, RoutedEventArgs e)
        {
            DataContext = PagesFabric.GetPage(typeof(RitualUrnServicePage));
        }

        private void OrdersContent(object sender, RoutedEventArgs e)
        {
            //DataContext = PagesFabric.GetPage(typeof(HomePage));
        }

        private void HomeContent(object sender, RoutedEventArgs e)
        {
            DataContext = PagesFabric.GetPage(typeof(HomePage));
        }

        private void HallsContent(object sender, RoutedEventArgs e)
        {
            DataContext = PagesFabric.GetPage(typeof(HallServicePage));
        }

        private void Window_MousDown(object sender, MouseButtonEventArgs e) 
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
