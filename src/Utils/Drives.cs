using System.IO;
using QuickFiles;

namespace QuickFiles.Utils
{
    public class Drives
    {
        public Drives(QuickFiles.Views.HomePage homePage)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            homePage.testOutput.Text = "";

            foreach (DriveInfo drive in drives)
            {
                var fname = drive.VolumeLabel;
                var bname = drive.Name.Replace("\\", "");

                if (drive.DriveType == DriveType.Removable)
                {
                    fname = "Removable Drive";
                }
                homePage.testOutput.Text += fname + " " + "(" + bname + ")" + "\n"; // guhh
            }
        }
    }
}