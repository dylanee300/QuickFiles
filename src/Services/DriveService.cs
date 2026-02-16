using System.IO;

namespace QuickFiles.Service
{
    public class Drives
    {
        public Drives(QuickFiles.Views.HomePage homePage)
        {
            DriveInfo[] Drives = DriveInfo.GetDrives();
            homePage.testOutput.Text = "";

            foreach (DriveInfo Drive in Drives)
            {
                var label = Drive.VolumeLabel;
                var name = Drive.Name.Replace("\\", "");

                if (Drive.DriveType == DriveType.Removable)
                {
                    label = "Removable Drive";
                }
            }

        }
    }
}
