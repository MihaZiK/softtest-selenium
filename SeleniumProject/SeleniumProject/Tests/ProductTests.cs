using NUnit.Framework;
using SeleniumProject.Wrappers;

namespace SeleniumProject.Tests
{
    [TestFixture]
    public class ProductTests : BaseTestSuite
    {
        [SetUp]
        public void SetupTest()
        {
            WebDriver.InitBrowser("Chrome");
            WebDriver.LoadApplication("http://localhost/litecart/public_html");
        }
        
        [Test]
        public void TestProductStickersCount()
        {
            Assert.IsTrue(Page.Main.StickersCountChecker());
        }
    }
}

