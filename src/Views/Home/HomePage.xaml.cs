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
		}

		private void BROWSE(object sender, RoutedEventArgs e)
		{
			string filePath = inputFilePathBox.Text;
			if (filePath == "")
			{
				// Fix: fixed issue with it crashing when no file path is provided
				// there's actually a lot more than this we need to check for and fix.. I know of a few currently
				testOutput.Text = "Please provide a valid file path";
				return;
			}
			if (filePath.Contains("."))
			{
				GetContent.Utils.GetContent getContent = new GetContent.Utils.GetContent(this);
			}
			else
			{
				GetFoldersInDir.Utils.GetFoldersInDir getFolders = new GetFoldersInDir.Utils.GetFoldersInDir(this);
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
			Add add = new Add(this);
		}

		private void DELETE(object sender, RoutedEventArgs e)
		{
			// way nicer usage no?
			Delete delete = new Delete();
			delete.DeleteService(this);
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
	}
}
