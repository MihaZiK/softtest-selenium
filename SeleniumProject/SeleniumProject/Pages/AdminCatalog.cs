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
    }
}