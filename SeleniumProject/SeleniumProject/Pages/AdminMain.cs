using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestsCardPayments.Wrappers;

namespace SeleniumProject.Pages
{
    public class AdminMain
    {
        [FindsBy(How = How.CssSelector, Using = "a[href*='logout.php']")]
        [CacheLookup]
        private IWebElement _logoutButton;

        public void ClickLogout()
        {
            BaseSelenium.Click(_logoutButton);
        }
    }
}