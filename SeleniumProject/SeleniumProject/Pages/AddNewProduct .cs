using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumProject.Wrappers;

namespace SeleniumProject.Pages
{
    public class AddNewProduct
    {
        [FindsBy(How = How.CssSelector, Using = "span [data-size=medium]")] 
        [CacheLookup]
        private IWebElement _name;
        
        [FindsBy(How = How.CssSelector, Using = "[name=code]")] 
        [CacheLookup]
        private IWebElement _code;
        
        [FindsBy(How = How.CssSelector, Using = "[value='1-1']")] 
        [CacheLookup]
        private IWebElement _maleCheck;
        
        [FindsBy(How = How.CssSelector, Using = "[name=quantity]")] 
        [CacheLookup]
        private IWebElement _quantity;
        
        [FindsBy(How = How.CssSelector, Using = "[type=file]")] 
        [CacheLookup]
        private IWebElement _file;
        
        [FindsBy(How = How.CssSelector, Using = "[name=date_valid_from]")] 
        [CacheLookup]
        private IWebElement _dateValidFrom;
        
        [FindsBy(How = How.CssSelector, Using = "[name=date_valid_to]")] 
        [CacheLookup]
        private IWebElement _dateValidTo;
        
        [FindsBy(How = How.CssSelector, Using = "[href*=information]")] 
        [CacheLookup]
        private IWebElement _informationTab;
        
        [FindsBy(How = How.CssSelector, Using = "[href*=prices]")] 
        [CacheLookup]
        private IWebElement _pricesTab;
        
        [FindsBy(How = How.CssSelector, Using = "[name=manufacturer_id]")] 
        [CacheLookup]
        private IWebElement _manufacturer;
        
        [FindsBy(How = How.CssSelector, Using = "[name=keywords]")] 
        [CacheLookup]
        private IWebElement _keywords;
        
        [FindsBy(How = How.CssSelector, Using = "[name*=short_description]")] 
        [CacheLookup]
        private IWebElement _shortDescription;
        
        [FindsBy(How = How.CssSelector, Using = ".trumbowyg-editor")] 
        [CacheLookup]
        private IWebElement _description;
        
        [FindsBy(How = How.CssSelector, Using = "[name*=head_title]")] 
        [CacheLookup]
        private IWebElement _headTitle;
        
        [FindsBy(How = How.CssSelector, Using = "[name*=meta_description]")] 
        [CacheLookup]
        private IWebElement _metaDescription;
        
        [FindsBy(How = How.CssSelector, Using = "label > [value='1']")] 
        [CacheLookup]
        private IWebElement _statusEnable;
        
        [FindsBy(How = How.CssSelector, Using = "[name=purchase_price]")] 
        [CacheLookup]
        private IWebElement _purchasePrice;
        
        [FindsBy(How = How.CssSelector, Using = "[name=purchase_price_currency_code]")] 
        [CacheLookup]
        private IWebElement _purchasePriceCode;
        
        [FindsBy(How = How.CssSelector, Using = "[name=save]")] 
        [CacheLookup]
        private IWebElement _saveAll;
        
        public void FillName(string name)
        {
            BaseSelenium.FillText(_name, name);
        }

        public void FillQuantity(string quantity)
        {
            BaseSelenium.FillText(_quantity, quantity);
        }

        public void FillCode()
        {
            BaseSelenium.FillText(_code, Helpers.Generator.ProductCodeGenerator());
        }
        
        public void FillDateFrom(string date)
        {
            BaseSelenium.FillText(_dateValidFrom, date);
        }
        
        public void FillDateTo(string date)
        {
            BaseSelenium.FillText(_dateValidTo, date);
        }

        public void FillKeywords(string keywords)
        {
            BaseSelenium.FillText(_keywords, keywords);
        }
        
        public void FillShortDescription(string descript)
        {
            BaseSelenium.FillText(_shortDescription, descript);
        }
        
        public void FillDescription(string descript)
        {
            BaseSelenium.FillText(_description, descript);
        }
        
        public void FillHeadTitle(string title)
        {
            BaseSelenium.FillText(_headTitle, title);
        }
        
        public void FillMetaDescription(string descript)
        {
            BaseSelenium.FillText(_metaDescription, descript);
        }

        public void ClickInformation()
        {
            BaseSelenium.Click(_informationTab);
            
        }

        public void ClickStatusEnable()
        {
            BaseSelenium.Click(_statusEnable);
        }

        public void SelectManufacturer(string name)
        {
            BaseSelenium.SelectByText(_manufacturer, name);
        }
        
        public void ClickPrices()
        {
            BaseSelenium.Click(_pricesTab);
        }

        public void FillPurchasePrice()
        {
            BaseSelenium.FillText(_purchasePrice, "25");
        }
        
        public void FillPurchasePriceCode()
        {
            BaseSelenium.SelectByText(_purchasePriceCode, "Euros");
        }

        public void ClickSave()
        {
            BaseSelenium.Click(_saveAll);
        }

        public void AttachFile()
        {
            var path = Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)) +
                          "\\Images\\Product.png";
            BaseSelenium.FillText(_file, path);
        }

        public void CheckMale()
        {
            BaseSelenium.Click(_maleCheck);
        }
        
    }
}