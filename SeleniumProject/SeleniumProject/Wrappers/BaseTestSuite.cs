using NUnit.Framework;

namespace TestsCardPayments.Wrappers
{
    public class BaseTestSuite
    {
        [SetUp]
        public void SetupTest()
        {
            WebDriver.InitBrowser("Chrome");
            WebDriver.LoadApplication("http://localhost/litecart/public_html/admin/");
        }
        
        [TearDown]
        public void TearDownTest()
        {
            WebDriver.CloseDriver();
        }
    }
}