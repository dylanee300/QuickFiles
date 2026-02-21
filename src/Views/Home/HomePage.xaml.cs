using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Input;

namespace QuickFiles.Views
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : UserControl
    {
        public HomePage()
        {
            InitializeComponent();
            LoadDrives();
        }

        private void LoadDrives()
        {
            if (DrivesList != null)
            {
                DrivesList.ItemsSource = Directory.GetLogicalDrives();
            }
        }

        private void DisplayDriveContents(object sender, RoutedEventArgs e)
        {
            string drivePath = (string)((Button)sender).Content;
            inputFilePathBox.Text = drivePath;
            BROWSE(sender, e);
        }

        public void BROWSE(object sender, RoutedEventArgs e)
        {
            string filePath = inputFilePathBox.Text;

            if (string.IsNullOrEmpty(filePath))
            {
                testOutput.Text = "Please provide a valid file path";
                return;
            }

            if (File.Exists(filePath))
            {
                Process.Start(new ProcessStartInfo(filePath)
                {
                    UseShellExecute = true
                });
            }
            else
            {
                QuickFiles.Actions.GetFoldersInDirs getFolders = new QuickFiles.Actions.GetFoldersInDirs(this);
            }
        }

        private void DESKTOP(object sender, RoutedEventArgs e)
        {
            inputFilePathBox.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            BROWSE(sender, e);
        }

        private void DOWNLOADS(object sender, RoutedEventArgs e)
        {
            inputFilePathBox.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + "\\Downloads";
            BROWSE(sender, e);
        }

        private void ADD(object sender, RoutedEventArgs e)
        {
            QuickFiles.Service.AddService addService = new QuickFiles.Service.AddService();
            addService.Add(this);
        }

        private void DELETE(object sender, RoutedEventArgs e)
        {
            QuickFiles.Service.DeleteService deleteService = new QuickFiles.Service.DeleteService();
            deleteService.Delete(this);
        }

        private void REFRESH(object sender, RoutedEventArgs e)
        {
            QuickFiles.Refresh refresh = new QuickFiles.Refresh(this);
        }

        private void DOCUMENTS(object sender, RoutedEventArgs e)
        {
            inputFilePathBox.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + "\\Documents";
            BROWSE(sender, e);
        }

        private void PICTRUES(object sender, RoutedEventArgs e)
        {
            inputFilePathBox.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + "\\Pictures";
            BROWSE(sender, e);

            inputFilePathBox.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + "\\OneDrive\\Pictures";
            BROWSE(sender, e);
        }

        private void VIDEOS(object sender, RoutedEventArgs e)
        {
            inputFilePathBox.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + "\\Videos";
            BROWSE(sender, e);
        }

        private void MUSIC(object sender, RoutedEventArgs e)
        {
            inputFilePathBox.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + "\\Music";
            BROWSE(sender, e);
        }

        private void DRIVES(object sender, RoutedEventArgs e)
        {
            QuickFiles.Service.Drives getDrives = new QuickFiles.Service.Drives(this);
        }

        private void OUTPUT_DOUBLECLICK(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (output.SelectedItem is ListBoxItem selectedItem && selectedItem.Tag is string path)
            {
                inputFilePathBox.Text = path;
                BROWSE(sender, e);
            }
        }

        private void HOME_CLICK(object sender, RoutedEventArgs e)
        {
            var userDir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
            inputFilePathBox.Text = userDir;
            BROWSE(sender, e);
        }

        private void BACK(object sender, RoutedEventArgs e)
        {
            string path = inputFilePathBox.Text;

            if (string.IsNullOrWhiteSpace(path))
                return;

            string root = Path.GetPathRoot(path);
            DirectoryInfo parent = Directory.GetParent(path);

            //Crash prevention if trying to go back when at root dir
            inputFilePathBox.Text = parent == null ? root : parent.FullName;
            BROWSE(sender, e);
        }

        private void SeachBox_Active(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (SearchBox.IsFocused)
                {
                    var search = new QuickFiles.Service.Search(this);
                    e.Handled = true;
                }
            }
        }
    }
}
