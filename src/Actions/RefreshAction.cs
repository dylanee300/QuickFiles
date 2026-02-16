using System.Windows;
using QuickFiles.Views;

namespace QuickFiles
{
    class Refresh
    {
        public Refresh(HomePage homePage)
        {
            homePage.DesktopButton.Visibility = Visibility.Visible;
            homePage.DownloadsButton.Visibility = Visibility.Visible;
            homePage.docsButton.Visibility = Visibility.Visible;
            homePage.picturesButton.Visibility = Visibility.Visible;

            homePage.inputFilePathBox.Text = string.Empty;
            homePage.testOutput.Text = string.Empty;
            homePage.output.Items.Clear();
        }
    }
}
