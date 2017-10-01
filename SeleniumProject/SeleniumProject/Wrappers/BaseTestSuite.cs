using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace SeleniumProject.Wrappers
{
    public class BaseTestSuite
    {        
        [SetUp]
        public void SetupTest()
        {
            WebDriver.InitBrowser("Firefox");
            WebDriver.LoadApplication("http://localhost/litecart/admin/");
        }
        
        [TearDown]
        public void TearDownTest()
        {
            WebDriver.CloseDriver();
        }
    }
}