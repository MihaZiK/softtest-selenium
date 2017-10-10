using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumProject.Wrappers
{
    public class BaseAsserts
    {
        public static bool IsElementPresent(By locator)
        {
            return WebDriver.Driver.FindElements(locator).Count > 0;
        }

        public static bool AreElementsPresent(By locator)
        {
            return WebDriver.Driver.FindElements(locator).Count > 0;
        }
    }
}