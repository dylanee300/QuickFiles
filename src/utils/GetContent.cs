using System;
using System.IO;
using System.Runtime.CompilerServices;
using QuickFiles;
using GetModified.Utils;

namespace GetContent.Utils
{
    class GetContent
    {
        public GetContent(MainWindow mainWindow)
        {
            string filePath = mainWindow.inputFilePathBox.Text.Trim();

            if (filePath != "")
            {
                if (File.Exists(filePath))
                {
                    string fileContent = File.ReadAllText(filePath);

                    mainWindow.testOutput.Text = fileContent;
                } else {
                    mainWindow.testOutput.Text = "file not found";
                }
            }
        }
    }
}