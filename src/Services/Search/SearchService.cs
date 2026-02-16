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

            var dirs = Directory.GetDirectories(filepath);

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
}
