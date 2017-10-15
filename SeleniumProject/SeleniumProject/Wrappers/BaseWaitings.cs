using System;
using System.Collections.ObjectModel;
using System.Threading;
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

        public static void WaitOpenNewWindow(ReadOnlyCollection<string> oldWin)
        {
            for (var count = 0;; count ++) {
                if (count >= 30)
                    throw new TimeoutException();
                try {
                    var newWin  = WebDriver.Driver.WindowHandles;
                    if (newWin.Count > oldWin.Count)
                        return;
                } catch (NoSuchElementException e) { }
                    Thread.Sleep(500);
            }
        }
    }
}