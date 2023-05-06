using Crematorium.UI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Crematorium.UI
{
    public class App : System.Windows.Application
    {
        readonly MainWindow startWindow;

        // через систему внедрения зависимостей получаем объект главного окна
        public App(MainWindow mainWindow)
        {
            this.startWindow = mainWindow;
            //this.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Resourse/Styles/BtnStyle.xaaml") };
            //this.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("pack://application:,,,/Resourse/Styles/BtnStyles.xaml") });
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            startWindow.Show();  // отображаем главное окно на экране
            base.OnStartup(e);
        }
    }
}
