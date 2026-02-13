using System;
using System.IO;
using System.Windows;

namespace QuickFiles.Service
{
    class AddService
    {
        private void RefreshToDesktop(QuickFiles.Views.HomePage homePage)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            homePage.inputFilePathBox.Text = desktopPath;
            QuickFiles.Actions.GetFoldersInDirs getFolders = new QuickFiles.Actions.GetFoldersInDirs(homePage);
        }

        public void Add(QuickFiles.Views.HomePage homePage)
        {
            string filePath = homePage.inputFilePathBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(filePath))
            {
                MessageBox.Show(
                    "Please enter a valid path to delete",
                    "Error",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning
                );
                return;
            }

            if (File.Exists(filePath))
            {
                var confirm = MessageBox.Show(
                    "Are you sure you would like to add",
                    "Confirm",
                    MessageBoxButton.YesNo
                );
                
                if (confirm == MessageBoxResult.Yes)
                {
                    File.Create(filePath).Close();
                    RefreshToDesktop(homePage);
                }
            }
        }
    }
}