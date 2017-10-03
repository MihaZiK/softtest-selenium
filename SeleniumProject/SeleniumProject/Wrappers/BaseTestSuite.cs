using NUnit.Framework;

namespace SeleniumProject.Wrappers
{
    public class BaseTestSuite
    {             
        [TearDown]
        public void TearDownTest()
        {
            WebDriver.CloseDriver();
        }
    }
}