using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Wrappers;

namespace SeleniumProject.Pages
{
    public class Cart
    {
        [FindsBy(How = How.CssSelector, Using = "td.item")]
        [CacheLookup]
        private IList<IWebElement> _ordersList;
        

        public void RemoveAllProducts()
        {
            while (BaseAsserts.IsElementPresent(By.CssSelector("[name=remove_cart_item]")))
            {
                BaseSelenium.Click(WebDriver.Driver.FindElement(By.CssSelector("[name=remove_cart_item]")));
                WebDriver.Wait.Until(ExpectedConditions.StalenessOf(_ordersList.First()));
            }
        }

        public bool CheckEmptyCart()
        {
            return BaseAsserts.IsElementPresent(By.CssSelector("em"));
        }
    }
}