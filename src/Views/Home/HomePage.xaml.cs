using System.IO;
using System.Windows;
using System.Windows.Controls;
using QuickFiles.Utils;
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

		private void BROWSE(object sender, RoutedEventArgs e)
		{
			string filePath = inputFilePathBox.Text;
			if (filePath == "")
			{
				testOutput.Text = "Please provide a valid file path";
				return;
			}
			if (filePath.Contains("."))
			{
				GetContent.Utils.GetContent getContent = new GetContent.Utils.GetContent(this);
			}
			else
			{
				GetFoldersInDir.Utils.GetFoldersInDirs getFolders = new GetFoldersInDir.Utils.GetFoldersInDirs(this);
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
			AddService addService = new AddService();
			addService.Add(this);
		}

		private void DELETE(object sender, RoutedEventArgs e)
		{
			DeleteService deleteService = new DeleteService();
			deleteService.Delete(this);
		}

		private void REFRESH(object sender, RoutedEventArgs e)
		{
			Refresh refresh = new Refresh(this);
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

		private void DRIVES(object sender, RoutedEventArgs e)
		{
			Drives getDrives = new Drives(this);
		}

		private void OUTPUT_DOUBLECLICK(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			if (output.SelectedItem is ListBoxItem selectedItem && selectedItem.Tag is string path)
			{
				inputFilePathBox.Text = path;
				BROWSE(sender, e);
			}
		}
	}
}
