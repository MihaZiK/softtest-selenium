using OpenQA.Selenium;

namespace SeleniumProject.Wrappers
{
    public class BaseAsserts
    {
        public static bool IsElementPresent(By locator)
        {
            return WebDriver.Driver.FindElements(locator).Count > 0;
        }
    }
}