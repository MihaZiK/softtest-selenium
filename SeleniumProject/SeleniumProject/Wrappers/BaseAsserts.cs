using OpenQA.Selenium;

namespace SeleniumProject.Wrappers
{
    public class BaseAsserts
    {
        public static bool IsElementsPresent(By locator)
        {
            try
            {
                WebDriver.Driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }
        }

        public static bool AreElementsPresent(By locator)
        {
            return WebDriver.Driver.FindElements(locator).Count > 0;
        }
    }
}