using System.IO;
using OpenQA.Selenium;

namespace Progressive_Edge_Test.utilities
{
    public static class SnapShot
    {

        public static string CaptureScreenShot(this IWebDriver driver)
        {
            string FilePath = Path.Combine(Properties.ResultDirectory, "Images");
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            FilePath = SnapShot.GetNextFile(FilePath);
            ss.SaveAsFile(FilePath, ScreenshotImageFormat.Png);
            string reportLink = FilePath.Replace(Properties.ResultDirectory, "").Replace("\\", "/");
            return reportLink.StartsWith("/") ? reportLink.Substring(1) : reportLink;
        }

        private static string GetNextFile(string screenCaptureDirectory)
        {
            if (!Directory.Exists(screenCaptureDirectory))
                Directory.CreateDirectory(screenCaptureDirectory);

            int fileIndex = 1;
            for (; File.Exists(Path.Combine(screenCaptureDirectory, "selenium_snap_" + fileIndex + ".png"));)
                fileIndex++;
            return Path.Combine(screenCaptureDirectory, "selenium_snap_" + fileIndex + ".png");
        }
    }
}
