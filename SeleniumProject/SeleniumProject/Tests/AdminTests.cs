using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumProject.Wrappers;

namespace SeleniumProject.Tests
{
    [TestFixture]
    public class Tests : BaseTestSuite
    {
        [SetUp]
        public new void SetupTest()
        {
            WebDriver.LoadApplication("http://localhost/litecart/admin/");
        }
        
        [Test]
        public void TestLoginAdmin()
        {
            Page.AdminLogin.loginAs("admin", "admin");
            Assert.IsTrue(WebDriver.Driver.FindElement(By.CssSelector("a[href*='logout.php']")).Displayed);
        }
        
        [Test]
        public void TestMenuClicker()
        {
            Page.AdminLogin.loginAs("admin", "admin");
            Assert.IsTrue(Page.AdminMain.MenuChecker());
        }
        
        // Проверка сортировки стран и зон со страницы Countries
        [Test]
        public void TestZonesAndCountiesOrder()
        {
            Page.AdminLogin.loginAs("admin", "admin");
            Page.AdminMain.ClickCountries();
            Assert.IsTrue(Page.AdminCountries.CheckZonesAndCountriesOrder());
        }
        
        // Проверка сортировки зон со страницы GeoZones
        [Test]
        public void TestZonesOfCountriesOrder()
        {
            Page.AdminLogin.loginAs("admin", "admin");
            Page.AdminMain.ClickGeoZones();
            Assert.IsTrue(Page.AdminGeoZones.CheckZonesOfCountriesOrder());
        }
    }
}