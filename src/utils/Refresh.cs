using System.IO;
using System.Windows.Controls.Primitives;

namespace QuickFiles
{
    class Refresh
    {
        public Refresh(MainWindow mainWindow)
        {
            var DesktopBox = mainWindow.DesktopButton;
            var DownloadsButt = mainWindow.DownloadsButton;
            var output = mainWindow.testOutput;

            DesktopBox.Visibility = System.Windows.Visibility.Visible;
            DownloadsButt.Visibility = System.Windows.Visibility.Visible;

            mainWindow.inputFilePathBox.Text = "";

            output.Text = "";
        }
    }
}