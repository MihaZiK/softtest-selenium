using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumProject.Wrappers;

namespace SeleniumProject.Pages
{
    public class AdminCatalog
    {
        [FindsBy(How = How.CssSelector, Using = "a[href*=edit_product]")] 
        [CacheLookup]
        private IWebElement _addNewProduct;
        
        public void ClickAddProduct()
        {
            BaseSelenium.Click(_addNewProduct);
        }

        public int GetCountRowsInTable()
        {
            return BaseSelenium.GetCountRowsInTable();
        }

        public void OpenAllFolders()
        {
            while (BaseAsserts.IsElementPresent(By.CssSelector(".fa-folder")))
            {
                BaseSelenium.Click(WebDriver.Driver.FindElement(By.XPath("//*[@class='fa fa-folder']/../a")));
            }
        }

        public bool CheckLogsWhenProductOpen()
        {
            var count = WebDriver.Driver.FindElements(By.CssSelector("td > img")).Count;
            for (var i = 0; i < count; i++)
            {
                IList<IWebElement> list = WebDriver.Driver.FindElements(By.XPath("//td/img/../a"));
                BaseSelenium.Click(list[i]);
                if (WebDriver.CheckBrowserLog())
                {
                    WebDriver.PrintBrowserLog();
                    return false;
                }
                WebDriver.Driver.Navigate().Back();
            }
            return true;
        }
    }
}