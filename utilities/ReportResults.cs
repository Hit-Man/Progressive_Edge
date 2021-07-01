using OpenQA.Selenium;
using System;


namespace Progressive_Edge_Test.utilities
{
   public static class ReportResults
    {
        public static void Fail(this Test test, string stepDescription, Exception ex, IWebDriver browser)
        {
            const string REPORT_LAYOUT = @"{0}<br/><tr><td rowspan='4' colspan='2'>{1}</td><td rowspan='4' colspan='2'><pre>{2}</pre></td></tr>";
            string message = ex.Message.Length > 300 ? ex.Message.Substring(0, 300) + "..." : ex.Message;
            string moreInfo = ex.StackTrace;
            var testEvidence = browser.Equals(null) ? string.Empty : test.AddScreenCapture(browser.CaptureScreenShot());
            test.ReportEvent(Test.Status.Failed, stepDescription, string.Format(REPORT_LAYOUT, message, testEvidence, moreInfo));
            test.EndTest();
            throw ex;
        }

        public static void Fail(this Test test, string stepDescription, string text, IWebDriver browser)
        {
            const string REPORT_LAYOUT = @"{0}<br/><tr><td rowspan='4' colspan='2'>{1}</td><td rowspan='4' colspan='2'><pre>{2}</pre></td></tr>";
            string message = text.Length > 300 ? text.Substring(0, 300) + "..." : text;
            string moreInfo = text.Length > 300 ? text : string.Empty;
            var testEvidence = browser.Equals(null) ? string.Empty : test.AddScreenCapture(browser.CaptureScreenShot());
            test.ReportEvent(Test.Status.Failed, stepDescription, string.Format(REPORT_LAYOUT, message, testEvidence, moreInfo));
            test.EndTest();

        }

        public static void Pass(this Test test, string stepDescription, IWebDriver browser)
        {
            var testEvidence = browser.Equals(null) ? string.Empty : test.AddScreenCapture(browser.CaptureScreenShot());
            test.ReportEvent(Test.Status.Passed, stepDescription, testEvidence);
            test.EndTest();
        }

        private static void EndTest(this Test test)
        {
            test.EndTest();
        }

    }
}
