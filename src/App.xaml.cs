using System.Configuration;
using System.Data;
using System.Windows;

namespace QuickFiles;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        try
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            mainWindow.Activate();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            MessageBox.Show(ex.Message);
        }
    }
}

