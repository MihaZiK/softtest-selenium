using NUnit.Framework;
using SeleniumProject.Wrappers;

namespace SeleniumProject.Tests
{
    [TestFixture]
    public class CountriesTests : BaseTestSuite
    {
        [SetUp]
        public new void SetupTest()
        {
            WebDriver.LoadApplication("http://localhost/litecart/admin/");
        }

        [Test]
        public void TestExternalLinks()
        {
            Page.AdminLogin.loginAs("admin","admin");
            Page.AdminMain.ClickCountries();
            Page.AdminCountries.ClickAddContry();
            Assert.IsTrue(Page.AdminEditCountry.CheckExternalLinks());
        }
    }
}