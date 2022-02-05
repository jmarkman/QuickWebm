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
        public IServiceProvider ServiceContainer { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            ServiceContainer = ConfigureServices();

            var window = ServiceContainer.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<QuickWebmConverterViewModel>();
            serviceCollection.AddSingleton(svc => new MainWindow()
            {
                DataContext = svc.GetRequiredService<QuickWebmConverterViewModel>()
            });
            serviceCollection.AddSingleton(svc => new VideoEffectsView()
            {
                DataContext = svc.GetRequiredService<VideoEffectsViewModel>()
            });
            serviceCollection.AddSingleton<WebmEncodingViewModel>();
            serviceCollection.AddSingleton<AdvancedOptionsViewModel>();
            serviceCollection.AddSingleton<IDialogService, DialogService>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
