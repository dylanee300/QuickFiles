using System.IO;
using System.Windows.Controls.Primitives;

namespace QuickFiles
{
    class Refresh
    {
        public Refresh(QuickFiles.Views.HomePage homePage)
        {
            var DesktopBox = homePage.DesktopButton;
            var DownloadsButt = homePage.DownloadsButton;
            var output = homePage.testOutput;

            DesktopBox.Visibility = System.Windows.Visibility.Visible;
            DownloadsButt.Visibility = System.Windows.Visibility.Visible;

            homePage.inputFilePathBox.Text = "";

            output.Text = "";
        }
    }
}