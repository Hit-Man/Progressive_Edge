using System;
using System.Linq;
using System.IO;
using System.Xml.Linq;

namespace Progressive_Edge_Test.utilities
{
   public static class Properties
    {
        private static XDocument doc;


        //instantiate properties file
        static Properties()
        {
            string myLocation = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory).Split(new string[] { "bin" }, StringSplitOptions.None)[0];
            string TEST_PROPERTIES_FILE = Path.Combine(myLocation, (@"properties\TestProperties.xml"));
            if (!File.Exists(TEST_PROPERTIES_FILE))
                throw new IOException(TEST_PROPERTIES_FILE + " must exist, please confirm existence.");
            doc = XDocument.Load(TEST_PROPERTIES_FILE);
        }

        //get application URL
        public static string ApplicationUnderTestURL
        {
            get
            {
                return doc.Root.Elements("Environment")
                    .Where(environment => environment.Attribute("Active").Value == "true").Elements()
                    .Elements("URL").First(element => element.Parent.Name == "UserInterface").Value;
            }
        }

        //Getting Browser to use when executing tests
        public static string BrowserName
        {
            get
            {
                return doc.Root.Elements("Environment").Where(environment => environment.Attribute("Active").Value == "true")
                    .Elements().Elements("BrowserName").First(element => element.Parent.Name == "Browser").Value;
            }
        }

        //get result directory to store report results

        public static string ResultDirectory
        {
            get
            {
                return doc.Root.Elements("Environment").Where(environment => environment.Attribute("Active").Value == "true")
                    .Elements().Elements("ResultsDirectory").First(element => element.Parent.Name == "Execution").Value;
            }
        }

        //Getting test environment
        public static string TestEnvironmentName
        {
            get
            {
                return doc.Root.Elements("Environment").Where(environment => environment.Attribute("Active").Value == "true")
                    .Attributes("Name").First().Value;
            }
        }

    }
}
