using AventStack.ExtentReports;

namespace Progressive_Edge_Test.utilities
{
    public class Test
    {
        private readonly ExtentReports extent;
        private ExtentTest test;

        public enum Status
        {
            Passed,
            Failed
        }

        public Test(ExtentReports extentReports)
        {
            extent = extentReports;
        }

        public void ReportEvent(Status status, string StepName, string Details)
        {
            AventStack.ExtentReports.Status state = Test.Status.Passed.Equals(status) ? AventStack.ExtentReports.Status.Pass : AventStack.ExtentReports.Status.Fail;
            test.Log(state, StepName);
        }

        public string AddScreenCapture(string ImagePath)
        {
            return test.AddScreenCaptureFromPath(ImagePath).ToString();
        }

        public Test StartTest(string Name, string Description)
        {
            test = extent.CreateTest(Name, Description);
            return this;
        }

        public void EndTest()
        {
            extent.Flush();

        }

        public ExtentTest GetTest()
        {
            return test;
        }

        public void SetTest(ExtentTest tst)
        {
            this.test = tst;
        }
    }
}
