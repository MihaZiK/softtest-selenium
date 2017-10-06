﻿using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumProject.Wrappers;

namespace SeleniumProject.Pages
{
    public class CreateAccount
    {
        [FindsBy(How = How.CssSelector, Using = "[name=firstname]")]
        [CacheLookup]
        private IWebElement _firstname;
        
        [FindsBy(How = How.CssSelector, Using = "[name=lastname]")]
        [CacheLookup]
        private IWebElement _lastname;
        
        [FindsBy(How = How.CssSelector, Using = "[name=address1]")]
        [CacheLookup]
        private IWebElement _adress1;
        
        [FindsBy(How = How.CssSelector, Using = "[name=postcode]")]
        [CacheLookup]
        private IWebElement _postcode;
        
        [FindsBy(How = How.CssSelector, Using = ".content [name=zone_code]")]
        [CacheLookup]
        private IWebElement _zone;
        
        [FindsBy(How = How.CssSelector, Using = "[name=city]")]
        [CacheLookup]
        private IWebElement _city;
        
        [FindsBy(How = How.CssSelector, Using = "[name=country_code]")]
        [CacheLookup]
        private IWebElement _country;
        
        [FindsBy(How = How.CssSelector, Using = "[name=email]")]
        [CacheLookup]
        private IWebElement _email;
        
        [FindsBy(How = How.CssSelector, Using = "[name=phone]")]
        [CacheLookup]
        private IWebElement _phone;
        
        [FindsBy(How = How.CssSelector, Using = "[name=password]")]
        [CacheLookup]
        private IWebElement _password;
        
        [FindsBy(How = How.CssSelector, Using = "[name=confirmed_password]")]
        [CacheLookup]
        private IWebElement _confirmedPassword;
        
        [FindsBy(How = How.CssSelector, Using = "[name=create_account]")]
        [CacheLookup]
        private IWebElement _create;
        

        public void FillFirstname(string text)
        {
            BaseSelenium.FillText(_firstname, text);
        }
        
        public void FillLastname(string text)
        {
            BaseSelenium.FillText(_lastname, text);
        }
        
        public void FillAdress1(string text)
        {
            BaseSelenium.FillText(_adress1, text);
        }

        public void FillPostcode(string text)
        {
            BaseSelenium.FillText(_postcode, text);
        }
        
        public void FillCity(string text)
        {
            BaseSelenium.FillText(_city, text);
        }

        public void SelectCountry(string country)
        {
            BaseSelenium.SelectByText(_country, country);
        }

        public void SelectZone(string zone)
        {
            BaseSelenium.SelectByText(_zone, zone);
        }
        
        public void FillEmail()
        {
            Console.WriteLine(Helpers.Generator.EmailGenerator());
            BaseSelenium.FillText(_email, Helpers.Generator.EmailGenerator());
        }

        public void FillPhone()
        {
            BaseSelenium.FillText(_phone, Helpers.Generator.PhoneGenerator());
        }

        public void FillPassword(string password)
        {
            BaseSelenium.FillText(_password, password);
        }
        
        public void FillConfirmPassword(string password)
        {
            BaseSelenium.FillText(_confirmedPassword, password);
        }

        public void ClickCreate()
        {
            BaseSelenium.Click(_create);
        }

        public void Registration()
        {
            FillFirstname("Tester");
            FillLastname("Tester");
            //FillAdress1("Test Street");
            FillPostcode("63212");
            FillCity("TestCity");
            SelectCountry("United States");
            SelectZone("Colorado");
            FillEmail();
            FillPhone();
            FillPassword("123QWEasd");
            FillConfirmPassword("123QWEasd");
            ClickCreate();
        }
        
    }
}