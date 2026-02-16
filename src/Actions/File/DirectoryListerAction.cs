using System.IO;
using QuickFiles;
using System.Windows.Controls;

namespace QuickFiles.Actions
{
    class GetFoldersInDirs
    {
        public GetFoldersInDirs(QuickFiles.Views.HomePage homePage)
        {

            /**
            ((Button)homePage.FindName("DesktopButton")).Visibility = Visibility.Collapsed;
            ((Button)homePage.FindName("DownloadsButton")).Visibility = Visibility.Collapsed;
            ((Button)homePage.FindName("docsButton")).Visibility = Visibility.Collapsed;
            ((Button)homePage.FindName("pictures")).Visibility = Visibility.Collapsed;
            */

            string filepath = homePage.inputFilePathBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(filepath))
                return;

            string fullpath = Path.GetFullPath(filepath);

            homePage.output.Items.Clear();
            homePage.testOutput.Text = "";

            if (!Directory.Exists(filepath)) { homePage.output.Items.Add("Path not found"); return; }

            string foldername = Path.GetFullPath(filepath);

            foreach (string dir in Directory.GetDirectories(fullpath))
            {
                string name = Path.GetFileName(dir);
                DateTime lastmodified = Directory.GetLastWriteTime(dir);
                var item = QuickFiles.Actions.AddListBoxItemAction.DirectoryItem(
                    dir,
                    Icon.Folder,
                    name,
                    lastmodified
                );
                homePage.output.Items.Add(item);
            }

            foreach (string file in Directory.GetFiles(fullpath))
            {
                string name = Path.GetFileName(file);
                FileInfo fileInfo = new FileInfo(file);
                var size = FormatFileSize.GetFileSize(fileInfo.Length);
                var item = QuickFiles.Actions.AddListBoxItemAction.FileItem(
                    file,
                    Icon.File,
                    name,
                    fileInfo.LastWriteTime,
                    size
                );
                homePage.output.Items.Add(item);
            }
        }
    }
}