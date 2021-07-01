using System;
using System.Configuration;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using Progressive_Edge_Test.utilities;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;


namespace Progressive_Edge_Test.pages
{

    [Binding]
    public class BaseStep : IDisposable
    {

        [BeforeTestRun]
        public static void SetUpTest()
        {
            _test = new Test(extent);
        }


        [AfterTestRun]
        public static void TeardDownTest()
        {
            if (extent != null)
                _test.EndTest();
        }


        [BeforeScenario]

        public void SetupScenario()
        {
            if (_ScenarioContext.ScenarioInfo.Title.Equals(GetIterationName()))
                IncreaseIteration();
            else
                ResetIteration();

            SetIterationName(_ScenarioContext.ScenarioInfo.Title);

            if (_test.GetTest() == null)
            {
                string testName = string.Format("{0} - Iteration {1}", _ScenarioContext.ScenarioInfo.Title, iteration);
                SetTest(_test.StartTest(testName, _FeatureContext.FeatureInfo.Description));
            }
        }


        [AfterScenario]

        public void TeardownScenario()

        {
            extent.Flush();
            ResetTest(null);
        }


        // context injection
        public BaseStep(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            this._ScenarioContext = scenarioContext;
            this._FeatureContext = featureContext;
        }



        [BeforeScenario("UX")]
        public void SetupUxScenario()
        {
            try
            {

                //chrome
                if (Properties.BrowserName == "chrome")
                {
                    ChromeOptions options = new ChromeOptions();
                    // options.AddArguments("--headless");
                    driver = new ChromeDriver(options);
                    _ScenarioContext["driver"] = driver;
                    driver.Manage().Window.Maximize();

                }

               
            }
            catch (Exception e)
            {
                _test.Fail("Setup browser: " + ConfigurationManager.AppSettings["browser"], e, null);

            }

        }


        [AfterScenario("UX")]

        public void TeardownUxScenario()
        {
            if (driver != null)
                Dispose();
        }


        [AfterStep]

        public void TeardownStep()
        {
            if (_test == null)
                return;
            if (_ScenarioContext.TestError != null)
                _test.Fail(_ScenarioContext.ScenarioInfo.Title, _ScenarioContext.TestError, driver);
        }


        public void Dispose()
        {
            try
            {
                if (this.driver != null)
                    this.driver.Close();
            }
            catch { }
        }



        #region private members

        private static void IncreaseIteration()
        {
            iteration++;
        }

        private static void ResetIteration()
        {
            iteration = 1;
        }


        private static void SetTest(Test test)
        {
            BaseStep._test = test;
        }


        private static void ResetTest(Test tst)

        {

            if (tst == null)
            {
                BaseStep.test.SetTest(null);
                return;
            }
            BaseStep._test.SetTest(tst.GetTest());
        }



        private static void SetIterationName(string name)

        {

            iterationName = name;

        }

        private static string GetIterationName()
        {
            return iterationName;
        }




        private static readonly ExtentReports extent = ReportManager.getInstance();
        private static Test _test;
        private static int iteration;
        private static string iterationName;
        private IWebDriver driver;
        private readonly ScenarioContext _ScenarioContext;
        private readonly FeatureContext _FeatureContext;

        #endregion

        public static Test test
        {
            get
            {
                return _test;
            }
        }
    }
}

