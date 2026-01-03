using System.Windows;
using GetContent;
using GetContent.Utils;
using GetFoldersInDir.Utils;
using QuickFiles.Utils;
namespace QuickFiles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = inputFilePathBox.Text;

            if (filePath.Contains("."))
            {
                GetContentFromFile getContent = new GetContentFromFile(this, filePath);
            }
            else
            {
                GetFoldersInDir getFolders = new GetFoldersInDir(this, filePath);
            }
        }

        private void DESKTOP_CLICK(object sender, RoutedEventArgs e)
        {
            inputFilePathBox.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            BrowseButton_Click(sender, e);
        }

        private void DOWNLOADS_CLICK(object sender, RoutedEventArgs e)  
        {
            inputFilePathBox.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + "\\Downloads";
            BrowseButton_Click(sender, e);
        }

        private void TEST_ADD_CLICK(object sender, RoutedEventArgs e)
        {
            Add add = new Add(this);
        }

        private void TEST_DEL_CLICK(object sender, RoutedEventArgs e)
        {
            DeleteFile delete = new DeleteFile(this);
        }


        private void REF_CLICK(object sender, RoutedEventArgs e)
        {
            Refresh refresh = new Refresh(this);
        }

        private void DOCS_CLICK(object sender, RoutedEventArgs e)
        {
            inputFilePathBox.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + "\\Documents";
            BrowseButton_Click(sender, e);
        }

        private void PIC_CLICK(object sender, RoutedEventArgs e)
        {
            inputFilePathBox.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + "\\Pictures";
            BrowseButton_Click(sender, e);
            
            inputFilePathBox.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + "\\OneDrive\\Pictures";
            BrowseButton_Click(sender, e);
        }

        private void DRIVES_CLICK(object sender, RoutedEventArgs e)
        {
            Drives getDrives = new Drives(this);
        }
    }
}