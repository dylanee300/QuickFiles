using System.IO;
using System;
using QuickFiles;
using System.Windows.Forms;
using System.Windows;
using System.Linq.Expressions;

namespace QuickFiles.Utils
{
    class DeleteFile
    {
        public DeleteFile(MainWindow mainWindow)
        {
            string filePath = Path.GetFullPath(mainWindow.inputFilePathBox.Text.Trim());

            var confirm = MessageBox.Show(
                "Are you sure you want to delete " + filePath + "?",
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
                        MessageBox.Show("File deleted", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        if (Directory.Exists(filePath))
                        {
                            Directory.Delete(filePath, true);
                            MessageBox.Show("Directory deleted", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        } else
                        {
                            MessageBox.Show(
                                "File or dir not found",
                                "Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error
                            );
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