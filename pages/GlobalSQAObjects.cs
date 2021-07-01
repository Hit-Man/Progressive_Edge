using OpenQA.Selenium.Support.PageObjects;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace Progressive_Edge_Test.pages
{
   public class GlobalSQAObjects
    {
        private readonly IWebDriver driver;
        public string url { get; set; }

        [CacheLookup]
        [FindsBy(How = How.XPath, Using = "//img[@src='images/high_tatras_min.jpg']")]
        public IWebElement HighTatrasImage { get; set; }

        [CacheLookup]
        [FindsBy(How = How.XPath, Using = "//img[@src='images/high_tatras2_min.jpg']")]
        public IWebElement HighTatrasImage2 { get; set; }

        [CacheLookup]
        [FindsBy(How = How.LinkText, Using = "DropDown Menu")]
        public IWebElement DropDownMenu { get; set; }

        [CacheLookup]
        [FindsBy(How = How.LinkText, Using = "Sample Page Test")]
        public IWebElement SamplePageLink { get; set; }

        [CacheLookup]
        [FindsBy(How = How.Id, Using = "g2599-name")]
        public IWebElement txtName { get; set; }

        [CacheLookup]
        [FindsBy(How = How.Id, Using = "g2599-email")]
        public IWebElement txtEmail { get; set; }

        [CacheLookup]
        [FindsBy(How = How.Id, Using = "g2599-website")]
        public IWebElement txtWebsite { get; set; }


        [CacheLookup]
        [FindsBy(How = How.Id, Using = "trash")]
        public IWebElement Trash { get; set; }

      

        public GlobalSQAObjects(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(this, new RetryingElementLocator(this.driver, TimeSpan.FromSeconds(10)));
        }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }

        public void DragPictureOne()
        {
            driver.SwitchTo().Frame(2);
            Actions Drag = new Actions(this.driver);
            Drag.DragAndDrop(HighTatrasImage, Trash).Build().Perform();
        }


        public void DragPictureTwo()
        {
            Actions Drag = new Actions(this.driver);
            Drag.DragAndDrop(HighTatrasImage2, Trash).Build().Perform();
        }

       public void SelectCountry(string Country)
        {
            IWebElement country = driver.FindElement(By.XPath("//option[contains(text(), '" + Country + "')]"));
            country.Click();
        }

       

        public void CaptureDetails(string Name, string Email, string Website)
        {
            txtName.SendKeys(Name);

            //  use tab key to move to next input field
            txtName.SendKeys(Keys.Tab);
         

            txtEmail.SendKeys(Email);
            txtWebsite.SendKeys(Website);
        }



    }
}
