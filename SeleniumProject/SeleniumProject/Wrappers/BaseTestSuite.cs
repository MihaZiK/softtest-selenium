using NUnit.Framework;

namespace TestsCardPayments.Wrappers
{
    public class BaseTestSuite
    {
        [SetUp]
        public void SetupTest()
        {
            WebDriver.InitBrowser("Chrome");
            WebDriver.LoadApplication("http://google.ru");
        }
        
        [TearDown]
        public void TearDownTest()
        {
            WebDriver.CloseDriver();
        }
    }
}