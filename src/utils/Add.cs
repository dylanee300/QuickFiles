using System.IO;
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
            }
        }
    }
}