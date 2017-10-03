using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

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
        
        public Dictionary<string, object> GetProductData()
        {
            var product = new Dictionary<string, object>
            {
                {"name", _title.Text},
                {"regular_price", GetRegularPriceData()},
                {"campaing-price", GetCampaignPriceData()}
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
    }
}