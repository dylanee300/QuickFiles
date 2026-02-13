using System;
using System.IO;
using System.Windows;

namespace QuickFiles.Service
{
    class DeleteService
    {
        private void RefreshToDesktop(QuickFiles.Views.HomePage homePage)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            homePage.inputFilePathBox.Text = desktopPath;
            QuickFiles.Actions.GetFoldersInDirs getFolders = new QuickFiles.Actions.GetFoldersInDirs(homePage);
        }

        public void Delete(QuickFiles.Views.HomePage homePage)
        {
            string filePath = homePage.inputFilePathBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(filePath))
            {
                homePage.testOutput.Text = "Please enter a valid path to delete";
                return;
            }

            if (!File.Exists(filePath) && !Directory.Exists(filePath))
            {
                homePage.testOutput.Text = "File or folder does not exist";
                return;
            }

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete\n{filePath}",
                "Confirm Delete",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (confirm != MessageBoxResult.Yes)
                return;

            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                else
                {
                    Directory.Delete(filePath, true);
                }

                homePage.testOutput.Text = "Deleted successfully";
                RefreshToDesktop(homePage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error deleting item\n{ex.Message}",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }
    }
}