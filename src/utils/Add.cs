/*using System.IO;
using System.Windows;
using QuickFiles;

namespace QuickFiles
{
    class AddFile
    {
        public AddFile(MainWindow mainWindow)
        {
            string filePath = mainWindow.inputFilePathBox.Text.Trim();
            if (filePath != "")
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                    mainWindow.testOutput.Text = "awesome! added file: " + filePath;

                    return;
                    
                }
            } else
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                    mainWindow.testOutput.Text = "awesome! added dir: " + filePath;

                    return;
                }
            }
        }
    }
}

*/

using System.IO;
using System.Windows;
using QuickFiles;

namespace QuickFiles;

class add
{
    public add(MainWindow main)
    {
        string filepath = main.inputFilePathBox.Text.Trim();
        if (filepath != "")
        {
            if (!File.Exists(filepath))
            {
                var confirm = MessageBox.Show(
                    "Are you sure you want to add " + filepath + "?",
                    "Confirm",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning
                );
                if (confirm == MessageBoxResult.Yes)
                {
                    File.Create(filepath).Close();
                    MessageBox.Show(
                        "File added: " + filepath,
                        "Success",
                        MessageBoxButton.OK
                    );
                    main.testOutput.Text = "awesome! added file: " + filepath;

                    return;

                }
            }
        }
    }
}