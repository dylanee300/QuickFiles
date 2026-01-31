using System;
using System.IO;

namespace GetContent.Utils
{
    class GetContent
    {
        public GetContent(QuickFiles.Views.HomePage homePage)
        {
            string filePath = homePage.inputFilePathBox.Text.Trim();

            if (string.IsNullOrEmpty(filePath))
            {
                homePage.testOutput.Text = "Please enter a file path";
                return;
            }

            if (!File.Exists(filePath))
            {
                homePage.testOutput.Text = "File not found";
                return;
            }

            try
            {
                string fileContent = File.ReadAllText(filePath);
                homePage.testOutput.Text = fileContent;
            }
            catch (Exception ex)
            {
                homePage.testOutput.Te   xt = $"Error reading file: {ex.Message}";
            }
        }
    }
}