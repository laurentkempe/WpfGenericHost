using System.Threading.Tasks;
using System.Windows;

namespace wpfGenericHost
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();

            await Task.FromResult(1);
        }

        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            await Task.FromResult(1);
        }
    }
}
