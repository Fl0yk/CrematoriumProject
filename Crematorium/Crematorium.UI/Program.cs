using Crematorium.Application.Abstractions;
using Crematorium.Application.Services;
using Crematorium.Domain.Abstractions;
using Crematorium.Persistense.Repository;
using Crematorium.UI.Pages;
using Crematorium.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crematorium.UI
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            // создаем хост приложения
            var host = Host.CreateDefaultBuilder()
                // внедряем сервисы
                .ConfigureServices(services => SetupServices(services))
                .Build();

            // получаем сервис - объект класса App
            var app = host.Services.GetService<App>();
            // запускаем приложения
            app?.Run();
        }

        private static void SetupServices(IServiceCollection services)
        {
            //Services
            services.AddSingleton<IUnitOfWork, FakeUnitOfWork>();
            services.AddSingleton<IUserService, UserService>();

            //Pages
            services.AddSingleton<App>();
            services.AddSingleton<MainWindow>();

            //ViewModels
            services.AddSingleton<LogAndRegVM>();
        }
    }
}
