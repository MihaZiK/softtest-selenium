using NUnit.Framework;
using OpenQA.Selenium;
using TestsCardPayments.Wrappers;

namespace SeleniumProject
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
    }
}