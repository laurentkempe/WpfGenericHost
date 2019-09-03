using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using System.Windows;
using System;

namespace wpfGenericHost
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;

        public App()
        {
            _host = new HostBuilder()
                            .ConfigureAppConfiguration((context, configurationBuilder) =>
                            {
                                configurationBuilder.SetBasePath(context.HostingEnvironment.ContentRootPath);
                                configurationBuilder.AddJsonFile("appsettings.json", optional: false);
                            })
                            .ConfigureServices((context, services) =>
                            {
                                services.Configure<Settings>(context.Configuration);

                                services.AddSingleton<ITextService, TextService>();
                                services.AddSingleton<MainWindow>();
                            })
                            .ConfigureLogging(logging =>
                            {
                                logging.AddConsole();
                            })
                            .Build();
        }

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            await _host.StartAsync();

            var mainWindow = _host.Services.GetService<MainWindow>();
            mainWindow.Show();
        }

        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync(TimeSpan.FromSeconds(5));
            }
        }
    }
}
