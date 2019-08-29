using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace wpfGenericHost
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;
        private readonly Settings _settings;


        public App()
        {
            _settings = new Settings();

            _host = new HostBuilder()
                            .ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) =>
                            {
                                configurationBuilder.SetBasePath(hostBuilderContext.HostingEnvironment.ContentRootPath);
                                configurationBuilder.AddJsonFile("appsettings.json", optional: false);

                                IConfigurationRoot configuration = configurationBuilder.Build();
                                configuration.Bind(_settings);
                            })
                            .ConfigureServices((HostBuilderContext, services) =>
                            {
                                services.AddSingleton<Settings>(_settings);
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
            await _host.StopAsync();

            _host.Dispose();
            _host = null;
        }
    }
}
