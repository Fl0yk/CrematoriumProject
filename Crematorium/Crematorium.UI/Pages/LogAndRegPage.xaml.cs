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
    /// Логика взаимодействия для LogAndRegPage.xaml
    /// </summary>
    public partial class LogAndRegPage : Window
    {
        private LogAndRegVM logAndRegVM;
        public LogAndRegPage(LogAndRegVM VM)
        {
            logAndRegVM = VM;
            InitializeComponent();
            DataContext = logAndRegVM;
        }

        private void Log_Click(object sender, RoutedEventArgs e)
        {
            if(logAndRegVM.OpenProgram())
            {
                MessageBox.Show("Успешная авторизация!");
            }
            else
            {
                MessageBox.Show("Такого аккаунта нет:(");
            }
            int k = 0;
        }
    }
}
