using System.IO;
using QuickFiles;

namespace GetModified.Utils
{
    class GetLastModified
    {
        public void GetLastModifiedTime(QuickFiles.Views.HomePage homePage)
        {
            string filePath = homePage.inputFilePathBox.Text;

            DateTime LASTMODIFIED = File.GetLastWriteTime(filePath);
            return;
        }
    }
} 