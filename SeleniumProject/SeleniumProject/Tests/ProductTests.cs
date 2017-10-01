using NUnit.Framework;
using SeleniumProject.Wrappers;

namespace SeleniumProject.Tests
{
    [TestFixture]
    public class ProductTests : BaseTestSuite
    {
        [SetUp]
        public new void SetupTest()
        {
            base.SetupTest();
            WebDriver.LoadApplication("http://localhost/litecart");
        }
        
        [Test]
        public void TestProductStickersCount()
        {
            Assert.IsTrue(Page.Main.StickersCountChecker());
        }
    }
}