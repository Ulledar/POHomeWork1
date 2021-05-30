using OpenQA.Selenium;
using POHomeWork1.Tests;
using System;

namespace POHomeWork1.Framework
{
    class Utils : BaseTest
    {
        public static void MakeScreenshot(string s)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string filePath = "C:/Users/Ulledar/source/repos/POHomeWork1/Resources/Screenshots/";
            ss.SaveAsFile(filePath + s + ".png", ScreenshotImageFormat.Png);
        }
    }
}
