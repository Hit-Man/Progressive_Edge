using System;
using System.Configuration;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;


namespace Progressive_Edge_Test.utilities
{
    public static class ReportManager
    {
        private static ExtentReports extent;
        private static ExtentV3HtmlReporter html;

        public static ExtentReports getInstance()
        {
            if (extent != null)
                return extent;
            html = new ExtentV3HtmlReporter(GetReportPath());
            LoadConfig();
            extent = new ExtentReports();
            GetSystemInfo();
            extent.AttachReporter(html);
            return extent;
        }

        private static string GetReportPath()
        {
            string filename = string.Format("Execution_report_on_{0}_at_{1}.html", ConfigurationManager.AppSettings["browser"], DateTime.Now.ToString("yyyy_MMMM_dd_hh_mm"));
            return Path.Combine(Properties.ResultDirectory, filename);
        }

        private static void LoadConfig()
        {
            string myLocation = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory).Split(new string[] { "bin" }, StringSplitOptions.None)[0];
            string reportConfig = Path.Combine(myLocation, (@"properties\extent-config.xml"));
            html.LoadConfig(reportConfig);
        }

        private static void GetSystemInfo()
        {
            extent.AddSystemInfo("Selenium Version", typeof(OpenQA.Selenium.IWebDriver).Assembly.GetName().Version.ToString());
            extent.AddSystemInfo("Browser Name", Properties.BrowserName);
            extent.AddSystemInfo("Environment", Properties.TestEnvironmentName);
            extent.AddSystemInfo("Application", Properties.ApplicationUnderTestURL);
        }



    }
}
