using Microsoft.Extensions.DependencyInjection;
using QuickWebm.Services;
using QuickWebm.ViewModels;
using QuickWebm.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace QuickWebm
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider serviceProvider;

        public App()
        {

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            serviceProvider = ConfigureServices();

            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }

        private IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IWindowService, WindowService>();
            services.AddScoped<MainWindow>();
            services.AddScoped<VideoEffectsView>();
            services.AddScoped<QuickWebmConverterViewModel>();
            services.AddScoped<VideoEffectsViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
