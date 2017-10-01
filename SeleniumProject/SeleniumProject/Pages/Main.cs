using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumProject.Pages
{
    public class Main
    {
        [FindsBy(How = How.CssSelector, Using = ".image-wrapper")]
        [CacheLookup]
        private IList<IWebElement> _productList;

        public bool StickersCountChecker()
        {
            return _productList.All(product => product.FindElements(By.CssSelector(".sticker")).Count == 1);
        }
    }
}