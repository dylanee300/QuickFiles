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
            

            if (filePath.Contains(".")) {
                // todo: use a better way to check if it's a file.. there's built in functions for this I'm just dumb
                GetContent.Utils.GetContent getContent = new GetContent.Utils.GetContent(this);
                return;
            } else
            {   
                 GetFoldersInDir.Utils.GetFoldersInDir getFoldersInDir = new GetFoldersInDir.Utils.GetFoldersInDir(this);

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

        // tests
        private void TEST_ADD_CLICK(object sender, RoutedEventArgs e)
        {
            AddFile add = new AddFile(this);
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
    }
}