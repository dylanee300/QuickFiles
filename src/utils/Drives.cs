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
            mainWindow.testOutput.Text = "";

            foreach (DriveInfo drive in drives)
            {
                var fname = drive.VolumeLabel;
                var bname = drive.Name.Replace("\\", "");

                // I can confirm that extenal drives do SHOW UP but can't confirm yet that the removable drive checks work.. yet
                if (drive.DriveType == DriveType.Removable)
                {
                    fname = "Removable Drive";
                }
                mainWindow.testOutput.Text += fname + " " + "(" + bname + ")" + "\n"; // guhh
            }
        }
    }
}