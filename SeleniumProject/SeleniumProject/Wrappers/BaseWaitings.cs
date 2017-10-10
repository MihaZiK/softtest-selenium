using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumProject.Wrappers
{
    public class BaseWaitings
    {
        public static void WaitTextPresent(IWebElement element, string text)
        {
            WebDriver.Wait.Until(ExpectedConditions.TextToBePresentInElement(element, text));
        }
        
        public static void WaitStalenessOf(IWebElement element)
        {
            WebDriver.Wait.Until(ExpectedConditions.StalenessOf(element));
        }
    }
}