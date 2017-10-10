using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumProject.Wrappers;

namespace SeleniumProject.Pages
{
    public class Product
    {
        [FindsBy(How = How.CssSelector, Using = "h1")]
        [CacheLookup]
        private IWebElement _title;
        
        [FindsBy(How = How.CssSelector, Using = ".regular-price")]
        [CacheLookup]
        private IWebElement _regularPrice;
        
        [FindsBy(How = How.CssSelector, Using = ".campaign-price")]
        [CacheLookup]
        private IWebElement _campaingPrice;
        
        [FindsBy(How = How.CssSelector, Using = "[name=add_cart_product]")]
        [CacheLookup]
        private IWebElement _addToCart;
        
        [FindsBy(How = How.CssSelector, Using = "[name*=Size]")]
        [CacheLookup]
        private IWebElement _selectSize;
        
        [FindsBy(How = How.CssSelector, Using = "span.quantity")]
        [CacheLookup]
        private IWebElement _quantityInCart;
        
        public Dictionary<string, object> GetProductData()
        {
            var product = new Dictionary<string, object>
            {
                {"name", _title.Text},
                {"regular_price", GetRegularPriceData()},
                {"campaign_price", GetCampaignPriceData()}
            };
            return product;
        }

        private Dictionary<string, string> GetRegularPriceData()
        {
            var regPrice = new Dictionary<string, string>
            {
                {"price", _regularPrice.Text},
                {"color", _regularPrice.GetCssValue("color")},
                {"font-size", _regularPrice.GetCssValue("font-size")},
                {"text-decoration", _regularPrice.GetCssValue("text-decoration")}
            };
            return regPrice;
        }
        
        private Dictionary<string, string> GetCampaignPriceData()
        {
            var camPrice = new Dictionary<string, string>
            {
                {"price", _campaingPrice.Text},
                {"color", _campaingPrice.GetCssValue("color")},
                {"font-size", _campaingPrice.GetCssValue("font-size")},
                {"font-weight", _campaingPrice.GetCssValue("font-weight")}
            };
            return camPrice;
        }

        public bool CheckThroughRegPrice()
        {
            var priceData = GetRegularPriceData();
            return Helpers.Check.CheckStyleLineThrough(priceData["text-decoration"]);
        }
        
        public bool CheckBoldCampPrice()
        {
            var priceData = GetCampaignPriceData();
            return Helpers.Check.CheckFontBold(priceData["font-weight"]);
        }

        public void ClickAddToCart()
        {
            if (BaseAsserts.IsElementPresent(By.CssSelector("[name*=Size]")))
                SelectProductSize("Medium");
            BaseSelenium.Click(_addToCart);
            BaseSelenium.WaitStalenessOf(_quantityInCart);
        }

        public void SelectProductSize(string size)
        {
            BaseSelenium.SelectByValue(_selectSize, size);
        }
        
    }
}