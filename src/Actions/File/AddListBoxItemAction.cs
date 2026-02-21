using System;
using System.Windows.Controls;

namespace QuickFiles.Actions
{
	public static class AddListBoxItemAction
	{
		public static ListBoxItem DirectoryItem(string dirPath, string icon, string name, DateTime lastModified)
		{
			var item = new ListBoxItem();
			item.Content = $"{icon} {name} (Last Modified: {lastModified})";
			item.Tag = dirPath;
			return item;
		}

		public static ListBoxItem FileItem(string filePath, string icon, string name, DateTime lastModified, string size)
		{
			var item = new ListBoxItem();
			item.Content = $"{icon} {name} (Last Modified: {lastModified}) (Size: {size})";
			item.Tag = filePath;
			return item;
		}
	}
}
