using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumProject.Wrappers
{
    public class BaseSelenium
    {        
        public static void FillText(IWebElement element, string text)
        {               
            WebDriver.Wait.Until(ExpectedConditions.ElementToBeClickable(element)).SendKeys(text);
        }

        public static void Click(IWebElement element)
        {
            WebDriver.Wait.Until(ExpectedConditions.ElementToBeClickable(element)).Click();
        }
        
        public static void DropDownListSelect(IWebElement element, string value)
        {
            var list = new SelectElement(element);
            list.SelectByValue(value);
        }

        public static void SelectByText(IWebElement element, string text)
        {
            new SelectElement(element).SelectByText(text);
        }
        
        public static void SelectByTextClicks(IWebElement element, string text)
        {
            Click(element);
            IList<IWebElement> optionsList = element.FindElements(By.CssSelector("option"));
            
            foreach (var option in optionsList)
            {
                if (option.Text == text) Click(option);
            }
        }
        
        public static void SelectByValue(IWebElement element, string value)
        {
            const string str = "document.querySelector('select[name=zone_code]')[5].selected=true";
            string s = "arguments[0].selectedIndex=5; arguments[0].dispatchEvent(new Event('change'));";
            string s1 = "document.querySelector('select[name=zone_code]').selectedIndex=5; " +
                        "document.querySelector('select[name=zone_code]').dispatchEvent(new Event('change'));";
            Console.WriteLine(s);
            ((IJavaScriptExecutor)WebDriver.Driver).ExecuteScript(s1);
        }

        public static void RefreshPage()
        {
            WebDriver.Driver.Navigate().Refresh();
        }

        public static IWebElement GetTableRowOfIndex(int index)
        {
            return WebDriver.Driver.FindElements(By.CssSelector(".dataTable .row"))[index];
        }
        
        public static int GetCountRowsInTable()
        {
            return WebDriver.Driver.FindElements(By.CssSelector(".dataTable .row")).Count;
        }

        public static IWebElement GetElementOfIndexFromRow(IWebElement row, int index)
        {
            return row.FindElements(By.CssSelector("td"))[index];
        }
        
        
        // JS Exp
        public static void ScrollPage(int x, int y)
        {
            ((IJavaScriptExecutor)WebDriver.Driver).ExecuteScript("window.scrollBy(" + x + "," + y + ");");
        }
        
        
    }
}