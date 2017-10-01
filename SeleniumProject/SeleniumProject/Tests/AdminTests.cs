using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumProject.Wrappers;

namespace SeleniumProject.Tests
{
    [TestFixture]
    public class Tests : BaseTestSuite
    {
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
    }
}