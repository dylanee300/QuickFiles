using System.IO;

namespace QuickFiles.Service
{
    class FileInfoService
    {
        public FileInfo FileInfo(QuickFiles.Views.HomePage homePage, string file)
        {
            return new FileInfo(file);
        }
    }
}