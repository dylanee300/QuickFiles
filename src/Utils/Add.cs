using System.IO;
using System.Windows;
using QuickFiles;

namespace QuickFiles;

class Add
{
    public Add(QuickFiles.Views.HomePage homePage)
    {
        string filepath = homePage.inputFilePathBox.Text.Trim();
        if (filepath != "")
        {
            if (!File.Exists(filepath))
            {
                var confirm = MessageBox.Show(
                    "Are you sure you want to add " + filepath + " ?",
                    "Confirm",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning
                );
                if (confirm == MessageBoxResult.Yes) 
                {
                    File.Create(filepath).Close();
                    // skip to desktop in kind of a weird way
                    string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
                    homePage.inputFilePathBox.Text = desktopPath;
                    GetFoldersInDir.Utils.GetFoldersInDir getFolders = new GetFoldersInDir.Utils.GetFoldersInDir(homePage);
                    // homePage.testOutput.Text = "Awesome! Added file: " + filepath;
                    return;
                }
            } 
        } 
    } 
}