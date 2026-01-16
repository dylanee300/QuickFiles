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
                    "Are you sure you want to add " + filepath + "?",
                    "Confirm",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning
                );
                if (confirm == MessageBoxResult.Yes)
                {
                    File.Create(filepath).Close();
                    MessageBox.Show(
                        "File added: " + filepath,
                        "Success",
                        MessageBoxButton.OK
                    );
                    homePage.testOutput.Text = "awesome! added file: " + filepath;
                    return;
                }
            }
        }
    }
}