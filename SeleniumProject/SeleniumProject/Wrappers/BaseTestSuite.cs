using NUnit.Framework;

namespace SeleniumProject.Wrappers
{
    public class BaseTestSuite
    {

        [SetUp]
        public void SetupTest()
        {
            WebDriver.InitBrowser("Firefox");
        }
        

        [TearDown]
        public void TearDownTest()
        {
            WebDriver.CloseDriver();
        }
    }
}