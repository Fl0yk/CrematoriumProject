using Crematorium.Application.Abstractions;
using Crematorium.Application.Services;
using Crematorium.Domain.Abstractions;
using Crematorium.Domain.Entities;
using Crematorium.Persistense.Data;
using Crematorium.Persistense.Repository;
using Crematorium.UI.Fabrics;
using Crematorium.UI.Pages;
using Crematorium.UI.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;

namespace Crematorium.UI
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            string settingsStream = "Crematorium.UI.appsettings.json";

            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream(settingsStream);
            var configuration = new ConfigurationBuilder().AddJsonStream(stream).Build();

            // создаем хост приложения
            var host = Host.CreateDefaultBuilder()
                // внедряем сервисы
                .ConfigureServices(services => SetupServices(services, configuration))
                .Build();
            
            // получаем сервис - объект класса App
            var app = host.Services.GetService<App>();

            PagesFabric.Services = host.Services;
            // запускаем приложения
            app?.Run();
        }

        private static void SetupServices(IServiceCollection services, IConfiguration config)
        {
            var connStr = config.GetConnectionString("SqliteConnection");


            //Data base
            services.AddDbContext<CrematoriumDbContext>(options =>
            {
                options.UseSqlite(connStr);
            });

            //Services
            services.AddSingleton<IUnitOfWork, FakeUnitOfWork>();
            //services.AddSingleton<IUnitOfWork, EfUnitOfWork>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IHelpersService<RitualUrn>, RitualUrnService>();
            services.AddSingleton<IHelpersService<Corpose>,  CorposeService>();
            services.AddSingleton<IHelpersService<Hall>, HallService>();

            //Pages
            services.AddSingleton<App>();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<HomePage>();
            services.AddSingleton<UsersPage>();
            services.AddSingleton<RitualUrnServicePage>();
            services.AddSingleton<CorposesServicePage>();
            services.AddSingleton<HallServicePage>();

            //Help pages
            services.AddTransient<ChangeUserPage>();
            services.AddTransient<ChangeUrnPage>();
            services.AddTransient<ChangeCorposePage>();

            //ViewModels
            services.AddSingleton<LogAndRegVM>();
            services.AddSingleton<HomeVM>();
            services.AddSingleton<UsersVM>();
            services.AddSingleton<UserChangeVM>();
            services.AddSingleton<RitualUrnsVM>();
            services.AddSingleton<ChangeUrnVM>();
            services.AddSingleton<CorposesVM>();
            services.AddSingleton<ChangeCorposeVM>();
            services.AddSingleton<HallServiceVM>();
        }
    }
}
