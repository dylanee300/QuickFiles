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

        /// <summary>
        /// Loads all the drives on the system and adds them to the DrivesList ListBox
        /// </summary>
        private void LoadDrives()
        {
            if (DrivesList != null)
            {
                DrivesList.ItemsSource = Directory.GetLogicalDrives();
            }
        }

        /// <summary>
        /// Displays the contents of the selected drive
        /// </summary>
        private void DisplayDriveContents(object sender, RoutedEventArgs e)
        {
            string drivePath = (string)((Button)sender).Content;
            inputFilePathBox.Text = drivePath;
            BROWSE(sender, e);
        }

        /// <summary>
        /// Opens the specified file path, if it's a directory it will display the contents, if it's a file it will open it with the default application or prompt them to select a app
        /// </summary>
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

        /// <summary>
        /// Display the user's desktop folder contents
        /// </summary>
        private void DESKTOP(object sender, RoutedEventArgs e)
        {
            inputFilePathBox.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            BROWSE(sender, e);
        }

        /// <summary>
        /// Display the user's downloads folder contents
        /// </summary>
        private void DOWNLOADS(object sender, RoutedEventArgs e)
        {
            inputFilePathBox.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + "\\Downloads";
            BROWSE(sender, e);
        }

        /// <summary>
        /// Adds a new file or folder to the current directory
        /// </summary>
        private void ADD(object sender, RoutedEventArgs e)
        {
            QuickFiles.Service.AddService addService = new QuickFiles.Service.AddService();
            addService.Add(this);
        }

        /// <summary>
        /// Deleted the selected file or folder from the current directory
        /// </summary>
        private void DELETE(object sender, RoutedEventArgs e)
        {
            QuickFiles.Service.DeleteService deleteService = new QuickFiles.Service.DeleteService();
            deleteService.Delete(this);
        }

        /// <summary>
        /// Refresh the current directory to show any changes that have been made (like adding or deleting files outside of the app)
        /// </summary>
        private void REFRESH(object sender, RoutedEventArgs e)
        {
            QuickFiles.Refresh refresh = new QuickFiles.Refresh(this);
        }

        /// <summary>
        /// Display the user's documents folder contents
        /// </summary>
        private void DOCUMENTS(object sender, RoutedEventArgs e)
        {
            inputFilePathBox.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + "\\Documents";
            BROWSE(sender, e);
        }

        /// <summary>
        /// Display the user's pictures folder contents
        /// </summary>
        private void PICTRUES(object sender, RoutedEventArgs e)
        {
            inputFilePathBox.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + "\\Pictures";
            BROWSE(sender, e);

            inputFilePathBox.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + "\\OneDrive\\Pictures";
            BROWSE(sender, e);
        }

        /// <summary>
        /// Display the user's videos folder contents
        /// </summary>
        private void VIDEOS(object sender, RoutedEventArgs e)
        {
            inputFilePathBox.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + "\\Videos";
            BROWSE(sender, e);
        }

        /// <summary>
        /// Display the user's music folder contents
        /// </summary>
        private void MUSIC(object sender, RoutedEventArgs e)
        {
            inputFilePathBox.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + "\\Music";
            BROWSE(sender, e);
        }

        /// <summary>
        /// UNUSED - Display drives on the system
        /// </summary>
        private void DRIVES(object sender, RoutedEventArgs e)
        {
            QuickFiles.Service.Drives getDrives = new QuickFiles.Service.Drives(this);
        }

        /// <summary>
        /// Handles double-clicking on an item in the output ListBox. If the item is a file it opens it in the default application, if it's a folder it will display the contents of that folder
        /// </summary>
        private void OUTPUT_DOUBLECLICK(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (output.SelectedItem is ListBoxItem selectedItem && selectedItem.Tag is string path)
            {
                inputFilePathBox.Text = path;
                BROWSE(sender, e);
            }
        }

        /// <summary>
        /// Display the user's home folder contents
        /// </summary>
        private void HOME_CLICK(object sender, RoutedEventArgs e)
        {
            var userDir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
            inputFilePathBox.Text = userDir;
            BROWSE(sender, e);
        }

        /// <summary>
        /// Navigates back to the parent directory of the current path. If they try to go back when at a root directory it will just refresh the current directory instead of crashing the app by trying to access a parent that doesn't exist
        /// </summary>
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

        /// <summary>
        /// Handles events from the user while the search box is focused, or they enterd a query
        /// </summary>
        private void SeachBox_Active(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (SearchBox.IsFocused && CheckBox.IsChecked == true)
                {
                    var search = new QuickFiles.Service.SearchAllSubDirectories(this);
                    e.Handled = true;
                }
                else if (SearchBox.IsFocused && CheckBox.IsChecked != true)
                {
                    var search = new QuickFiles.Service.Search(this);
                    e.Handled = true;
                }
            } 
            else if (SearchBox.IsFocused)
            {
                SearchPlaceholder.Text = string.Empty;
            }
        }
    }
}