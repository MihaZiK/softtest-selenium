using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumProject.Wrappers;

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

        public bool MenuChecker()
        {
            for (var i = 0; i < WebDriver.Driver.FindElements(By.Id("app-")).Count; i++)
            {
                BaseSelenium.Click(WebDriver.Driver.FindElements(By.Id("app-"))[i]);
                if (!BaseAsserts.IsElementsPresent(By.CssSelector("h1")))
                    return false;
            }
            return true;
        }
    }
}