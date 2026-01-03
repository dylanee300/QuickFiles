using System.IO;
using QuickFiles;

namespace QuickFiles.Utils
{
    public class Drives
    {
        public Drives(MainWindow mainWindow)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            var amount = drives.Length;
            foreach (DriveInfo drive in drives)
            {
                mainWindow.testOutput.Text += drive.Name + "\n";
            }
        }
    }
}