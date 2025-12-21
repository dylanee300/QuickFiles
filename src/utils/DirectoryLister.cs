using System;
using System.IO;
using System.Windows;
using GetModified.Utils;
using QuickFiles;

namespace GetFoldersInDir.Utils
{
    class GetFoldersInDir
    {
        public GetFoldersInDir(MainWindow mainWindow)
        {
            string filePath = Path.GetFullPath(mainWindow.inputFilePathBox.Text.Trim());

            // emojis are placeholders until I figure out how to do the images correctly, plus they show up as black and white so it's a bonus

            if (filePath != "")
            {
                if (Directory.Exists(filePath))
                {
                    string[] dirs = Directory.GetDirectories(filePath);
                    string[] files = Directory.GetFiles(filePath);
                    string FFolderName = Path.GetFileName(filePath);
                    mainWindow.testOutput.Text = "Folders in " + FFolderName + ":\n";
                    foreach (string dir in dirs)
                    {
                     string image = "📁 ";
                     string folderName = Path.GetFileName(dir);

                    // this is apart of my attempt to display the clicked dir
                    string[] DIRS = Directory.GetDirectories(filePath);

                      DateTime LASTMODIFIED = File.GetLastWriteTime(dir);
                        mainWindow.testOutput.Text += image + folderName + " (Last Modified: " + LASTMODIFIED + ")\n";
                    }
                    string fileNamee = Path.GetFileName(filePath);
                    mainWindow.testOutput.Text += "\nFiles in " + fileNamee + ":\n";
                    foreach (string file in files)
                    {
                        string fileName = Path.GetFileName(file);
                        string image = "📄 ";


                        DateTime LASTMODIFIED = File.GetLastWriteTime(file);
                        mainWindow.testOutput.Text += image + fileName + " (Last Modified: " + LASTMODIFIED + ")\n";
                    }
                }
                else
                {
                    mainWindow.testOutput.Text = "directory not found";
                }
            }

        }
    }
}