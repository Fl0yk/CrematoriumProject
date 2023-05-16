using Crematorium.UI.Fabrics;
using Crematorium.UI.Pages;
using System.Windows;
using System.Windows.Input;

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

        private void ClosePr(object sender, RoutedEventArgs e)
        {
            foreach (Window w in App.Current.Windows)
            {
                w.Close();
            }
            //Close();
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
