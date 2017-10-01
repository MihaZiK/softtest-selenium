using System;
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
            // Идем по списку всех элементов меню
            for (var i = 0; i < WebDriver.Driver.FindElements(By.Id("app-")).Count; i++)
            {
                IWebElement menuItem = WebDriver.Driver.FindElements(By.Id("app-"))[i];    
                BaseSelenium.Click(menuItem);
                
                // Если есть подменю, то проходим и по нему
                if (BaseAsserts.AreElementsPresent(By.CssSelector("ul.docs li")))
                {
                    for (var j = 0; j < WebDriver.Driver.FindElements(By.CssSelector("ul.docs li")).Count; j++)
                    {
                        menuItem = WebDriver.Driver.FindElements(By.CssSelector("ul.docs li"))[j]; 
                        BaseSelenium.Click(menuItem);
                        if (!BaseAsserts.IsElementsPresent(By.CssSelector("h1")))
                            return false;
                    }
                }
                if (!BaseAsserts.IsElementsPresent(By.CssSelector("h1")))
                    return false;
            }
            return true;
        }
    }
}