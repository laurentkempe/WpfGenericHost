using System;
using System.Windows;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace wpfGenericHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IHost _webApiHost;

        public MainWindow(ITextService textService)
        {
            _webApiHost = Host.CreateDefaultBuilder()
                                    .ConfigureWebHostDefaults(webBuilder =>
                                    {
                                        webBuilder.UseStartup<Startup>();
                                    })
                                    .Build();

            InitializeComponent();

            Label.Content = textService.GetText();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await _webApiHost.RunAsync();
        }

        private async void Window_Closed(object sender, EventArgs e)
        {
            await _webApiHost.StopAsync();
        }
    }
}
