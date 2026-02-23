using System;
using System.IO;

namespace QuickFiles.Service
{
    public class Search
    {
        public Search(QuickFiles.Views.HomePage homePage)
        {
            string filepath = homePage.inputFilePathBox.Text?.Trim();
            string query = homePage.SearchBox.Text?.Trim();

            if (string.IsNullOrEmpty(filepath) || string.IsNullOrEmpty(query))
                return;

            if (!Directory.Exists(filepath))
                return;

            homePage.output.Items.Clear();

            var dirs = Directory.EnumerateDirectories(filepath); //Better memory performance than .GetDirectories()

            foreach (var dir in dirs)
            {
                string name = Path.GetFileName(dir);
                if (name.Contains(query, StringComparison.OrdinalIgnoreCase))
                {
                    DateTime lastModified = Directory.GetLastWriteTime(dir);
                    var item = QuickFiles.Actions.AddListBoxItemAction.DirectoryItem(
                        dir,
                        Icon.Folder,
                        name,
                        lastModified
                    );
                    homePage.output.Items.Add(item);
                }
            }
        }
    }
    public class SearchAllSubDirectories
    {
        public SearchAllSubDirectories(QuickFiles.Views.HomePage homePage)
        {
            string filePath = homePage.inputFilePathBox.Text?.Trim();
            string query = homePage.SearchBox.Text?.Trim();

            if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(query))
                return;
            
            if (!Directory.Exists(filePath))
                return;
            
            homePage.output.Items.Clear();

            var allDirs = Directory.GetDirectories(filePath, "*", SearchOption.AllDirectories);
            var allFiles = Directory.GetFiles(filePath, "*.*", SearchOption.AllDirectories);

            foreach (var dir in allDirs)
            {
                string name = Path.GetFileName(dir);
                if (name.Contains(query, StringComparison.OrdinalIgnoreCase))
                {
                    DateTime lastModified = Directory.GetLastWriteTime(dir);
                    var item = QuickFiles.Actions.AddListBoxItemAction.DirectoryItem(
                        dir,
                        Icon.Folder,
                        name,
                        lastModified
                    );
                    homePage.output.Items.Add(item);
                }
            }
            foreach (var file in allFiles)
            {
                string name = Path.GetFileName(file);
                if (name.Contains(query, StringComparison.OrdinalIgnoreCase))
                {
                    DateTime lastModified = File.GetLastWriteTime(file);
                    long sizeInBytes = new FileInfo(file).Length;
                    string sizeFormatted = FormatFileSize.GetFileSize(sizeInBytes);
                    var item = QuickFiles.Actions.AddListBoxItemAction.FileItem(
                        file,
                        Icon.File,
                        name,
                        lastModified,
                        sizeFormatted
                    );
                    homePage.output.Items.Add(item);
                }
            }
        }
    }
}
