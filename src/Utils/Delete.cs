using System.IO;
using System.Windows;

namespace QuickFiles.Utils
{
    class Delete
    {

        private void RefreshToDesktop(QuickFiles.Views.HomePage homePage)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            homePage.inputFilePathBox.Text = desktopPath;
            new GetFoldersInDir.Utils.GetFoldersInDir(homePage);
        }
        public void DeleteService(QuickFiles.Views.HomePage homePage)
        {
            string filePath = homePage.inputFilePathBox.Text.Trim();
            
            if (string.IsNullOrWhiteSpace(filePath))
            {
                homePage.testOutput.Text = "Please enter a valid path to delete";
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to delete " + filePath + " ?",
                "Confirm",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (confirm == MessageBoxResult.Yes)
            {
                try
                {
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                        RefreshToDesktop(homePage);
                        return;
                    } else
                    {
                        if (Directory.Exists(filePath))
                        {
                            Directory.Delete(filePath, true);
                            RefreshToDesktop(homePage);
                            return;
                        }
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error deleting file: " + ex.Message,
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                }
            }
        }   
    }
}