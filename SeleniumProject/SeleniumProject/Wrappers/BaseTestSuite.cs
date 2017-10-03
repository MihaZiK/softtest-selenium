using NUnit.Framework;

namespace SeleniumProject.Wrappers
{
    public class BaseTestSuite
    {        
        [SetUp]
        public void SetupTest()
        {
            WebDriver.InitBrowser("Chrome");
        }
        
        [TearDown]
        public void TearDownTest()
        {
            WebDriver.CloseDriver();
        }
    }
}