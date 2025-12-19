using System.IO;
using QuickFiles;

namespace GetModified.Utils
{
    class GetLastModified
    {
        public void GetLastModifiedTime(MainWindow mainWindow)
        {
            string filePath = mainWindow.inputFilePathBox.Text;

            DateTime LASTMODIFIED = File.GetLastWriteTime(filePath);
            return;
        }
    }
} 