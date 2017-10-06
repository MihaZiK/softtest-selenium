using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumProject.Wrappers;

namespace SeleniumProject.Pages
{
    public class Main
    {
        [FindsBy(How = How.CssSelector, Using = ".image-wrapper")] 
        [CacheLookup]
        private IList<IWebElement> _productList;

        [FindsBy(How = How.CssSelector, Using = "#box-campaigns li:first-child")] 
        [CacheLookup]
        private IList<IWebElement> _campaignsProducts;
        
        [FindsBy(How = How.CssSelector, Using = "[name=email]")] 
        [CacheLookup]
        private IWebElement _email;
        
        [FindsBy(How = How.CssSelector, Using = "[name=password]")] 
        [CacheLookup]
        private IWebElement _password;
        
        [FindsBy(How = How.CssSelector, Using = ".content a[href*=create_account]")] 
        [CacheLookup]
        private IWebElement _registration;
        
        [FindsBy(How = How.CssSelector, Using = "[href*=logout]")] 
        [CacheLookup]
        private IWebElement _logout;
        
        [FindsBy(How = How.CssSelector, Using = "[name=login]")] 
        [CacheLookup]
        private IWebElement _login;

        public bool StickersCountChecker()
        {
            return _productList.All(product => product.FindElements(By.CssSelector(".sticker")).Count == 1);
        }

        public void ClickCampaignProductByIndex(int index)
        {
            BaseSelenium.Click(_campaignsProducts[index]);
        }

        public void ClickRegistration()
        {
            BaseSelenium.Click(_registration);
        }

        public void ClickLogout()
        {
            BaseSelenium.Click(_logout);
        }
        
        public void FillEmail(string email)
        {
            BaseSelenium.FillText(_email, email);
        }
        
        public void FillPassword(string password)
        {
            BaseSelenium.FillText(_password, password);
        }
        
        public void ClickLogin()
        {
            BaseSelenium.Click(_login);
        }

        public void Login(string email, string password)
        {
            FillEmail(email);
            FillPassword(password);
            ClickLogin();
        }

        public Dictionary<string, object> GetCampaignProduct(int index)
        {
            var product = new Dictionary<string, object>
            {
                {"name", _campaignsProducts[index].FindElement(By.CssSelector(".name")).Text},
                {"regular_price", GetProductRegPriceData(_campaignsProducts[index])},
                {"campaign_price", GetProductCampPriceData(_campaignsProducts[index])}
            };
            return product;
        }

        private static Dictionary<string, string> GetProductRegPriceData(ISearchContext product)
        {
            var regPrice = new Dictionary<string, string>
            {
                {"price", product.FindElement(By.CssSelector(".regular-price")).Text},
                {"color", product.FindElement(By.CssSelector(".regular-price")).GetCssValue("color")},
                {
                    "font-size", product.FindElement(By.CssSelector(".regular-price"))
                        .GetCssValue("font-size")
                },
                {
                    "text-decoration", product.FindElement(By.CssSelector(".regular-price"))
                        .GetCssValue("text-decoration")
                }
            };
            return regPrice;
        }
        
        private static Dictionary<string, string> GetProductCampPriceData(ISearchContext product)
        {
            var camPrice = new Dictionary<string, string>
            {
                {"price", product.FindElement(By.CssSelector(".campaign-price")).Text},
                {"color", product.FindElement(By.CssSelector(".campaign-price")).GetCssValue("color")},
                {
                    "font-size", product.FindElement(By.CssSelector(".campaign-price"))
                        .GetCssValue("font-size")
                },
                {
                    "font-weight", product.FindElement(By.CssSelector(".campaign-price"))
                        .GetCssValue("font-weight")
                }
            };
            return camPrice;
        }
    }
}