using System.Windows;
using QuickFiles.Views;

namespace QuickFiles
{
    class Refresh
    {
        public Refresh(HomePage homePage)
        {
            string currentPath = homePage.inputFilePathBox.Text.Trim();
            //Dummy sender and RoutedEventArgs
            object sender = homePage;
            RoutedEventArgs e = new RoutedEventArgs(); 

            homePage.BROWSE(sender, e);           
        }
    }
}