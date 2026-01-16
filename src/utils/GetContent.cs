using System;
using System.IO;
using System.Runtime.CompilerServices;
using QuickFiles;
using GetModified.Utils;

namespace GetContent.Utils
{
    class GetContent
    {
        public GetContent(QuickFiles.Views.HomePage homePage)
        {
            string filePath = homePage.inputFilePathBox.Text.Trim();

            if (filePath != "")
            {
                if (File.Exists(filePath))
                {
                    string fileContent = File.ReadAllText(filePath);

                    homePage.testOutput.Text = fileContent;
                } else {
                    homePage.testOutput.Text = "file not found";
                }
            }
        }
    }
}