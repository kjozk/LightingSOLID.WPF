using LightingDevice.UI.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace LightingDevice.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainViewModel = new MainViewModel();
            var mainWindow = new MainWindow() { DataContext = mainViewModel };

            mainWindow.Show();
        }
    }
}
