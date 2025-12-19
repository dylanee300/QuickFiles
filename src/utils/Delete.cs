using System.IO;
using System.Windows;


namespace QuickFiles
{

    class DeleteFile
    {
        public DeleteFile(MainWindow mainWindow)
        {
            string filePath = mainWindow.inputFilePathBox.Text.Trim();
            if (filePath != "")
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    mainWindow.testOutput.Text = "file deleted: " + filePath;
                } /* else
                // commented out so I don't delete shit in my desktop again!! rip cs2, discord and other apps
                {
                    if (Directory.Exists(filePath))
                    {
                        Directory.Delete(filePath, true);
                        mainWindow.testOutput.Text = "dir deleted: " + filePath;
                    }
                }
                */
            } 
        }
    }
}