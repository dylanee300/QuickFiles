using System;
using QuickFiles;
using System.IO;
using System.Windows;

namespace QuickFiles.Utils
{
    class EstimateMousePos
    {
        public EstimateMousePos(MainWindow mainWindow)
        {
            Point mousePos = System.Windows.Input.Mouse.GetPosition(mainWindow);
            mainWindow.testOutput.Text = "Mouse Position - X: " + mousePos.X + ", Y: " + mousePos.Y;
        }
    }
}