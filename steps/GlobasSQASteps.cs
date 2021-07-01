using NUnit.Framework;
using TechTalk.SpecFlow;
using Progressive_Edge_Test.utilities;
using Progressive_Edge_Test.pages;
using OpenQA.Selenium;


namespace Progressive_Edge_Test.steps
{
    [Binding]
    public class GlobasSQASteps : Steps
    {
        private GlobalSQAObjects globalSQAobjects;
        private readonly ScenarioContext _ScenarioContext;
        private readonly FeatureContext _FeatureContext;
        private readonly Test test = BaseStep.test;
        IWebDriver driver;


        //context injection 
        //for running parallel tests
        private GlobasSQASteps(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            this._ScenarioContext = scenarioContext;

        }

        [Given(@"I successfully navigate to Global SQA")]
        public void GivenISuccessfullyNavigateToGlobalSQA()
        {
            string stepDescription = string.Format("{0}: {1}", _ScenarioContext.CurrentScenarioBlock, _ScenarioContext.StepContext.StepInfo.Text);
            driver = (IWebDriver)_ScenarioContext["driver"];
            globalSQAobjects = new GlobalSQAObjects(driver);
            globalSQAobjects.url = Properties.ApplicationUnderTestURL;
            globalSQAobjects.Navigate();
            StringAssert.Contains("Drag and Drop Demo Sites | Testing Site - GlobalSQA", driver.Title, stepDescription);
            test.Pass(stepDescription, (IWebDriver)_ScenarioContext["driver"]);

        }

        [When(@"I drag the first picture into the trash area")]
        public void WhenIDragTheFirstPictureIntoTheTrashArea()
        {
            string stepDescription = string.Format("{0}: {1}", _ScenarioContext.CurrentScenarioBlock, _ScenarioContext.StepContext.StepInfo.Text);
            driver = (IWebDriver)_ScenarioContext["driver"];
            globalSQAobjects.DragPictureOne();
            test.Pass(stepDescription, (IWebDriver)_ScenarioContext["driver"]);

        }

        [When(@"I drag the second picture into the trash area")]
        public void WhenIDragTheSecondPictureIntoTheTrashArea()
        {
            string stepDescription = string.Format("{0}: {1}", _ScenarioContext.CurrentScenarioBlock, _ScenarioContext.StepContext.StepInfo.Text);
            driver = (IWebDriver)_ScenarioContext["driver"];
            globalSQAobjects.DragPictureTwo();
            test.Pass(stepDescription, (IWebDriver)_ScenarioContext["driver"]);
        }

        [Then(@"the trash area should contain two images")]
        public void ThenTheTrashAreaShouldContainTwoImages()
        {
            string stepDescription = string.Format("{0}: {1}", _ScenarioContext.CurrentScenarioBlock, _ScenarioContext.StepContext.StepInfo.Text);
            driver = (IWebDriver)_ScenarioContext["driver"];
            globalSQAobjects.DragPictureTwo();
            test.Pass(stepDescription, (IWebDriver)_ScenarioContext["driver"]);
        }

        [When(@"I click on the DropDown Menu link")]
        public void GivenIClickOnTheDropDownMenuLink()
        {
            string stepDescription = string.Format("{0}: {1}", _ScenarioContext.CurrentScenarioBlock, _ScenarioContext.StepContext.StepInfo.Text);
            driver = (IWebDriver)_ScenarioContext["driver"];
            globalSQAobjects.DropDownMenu.Click();
            test.Pass(stepDescription, (IWebDriver)_ScenarioContext["driver"]);
        }

        [Then(@"I should be able to select a (.*)")]
        public void ThenIShouldBeAbleToSelectA(string Country)
        {
            string stepDescription = string.Format("{0}: {1}", _ScenarioContext.CurrentScenarioBlock, _ScenarioContext.StepContext.StepInfo.Text);
            driver = (IWebDriver)_ScenarioContext["driver"];
            globalSQAobjects.SelectCountry(Country);
            test.Pass(stepDescription, (IWebDriver)_ScenarioContext["driver"]);
        }

        [Given(@"I click on the Sample Page Test link")]
        public void GivenIClickOnTheSamplePageTestLink()
        {
            string stepDescription = string.Format("{0}: {1}", _ScenarioContext.CurrentScenarioBlock, _ScenarioContext.StepContext.StepInfo.Text);
            driver = (IWebDriver)_ScenarioContext["driver"];

           
           
            //avoid test failing due to no focus
           
            globalSQAobjects.SamplePageLink.Click();
            test.Pass(stepDescription, (IWebDriver)_ScenarioContext["driver"]);
        }


        [Then(@"I should be able to fill in the (.*) (.*) and (.*) info")]
        public void ThenIShouldBeAbleToFillInTheAndInfo(string Name, string Email, string Website)
        {
            string stepDescription = string.Format("{0}: {1}", _ScenarioContext.CurrentScenarioBlock, _ScenarioContext.StepContext.StepInfo.Text);
            driver = (IWebDriver)_ScenarioContext["driver"];
            globalSQAobjects.CaptureDetails(Name,Email,Website);
            test.Pass(stepDescription, (IWebDriver)_ScenarioContext["driver"]);
        }














    }
}

