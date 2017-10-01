﻿using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumProject.Wrappers;

namespace SeleniumProject.Pages
{
    public class AdminGeoZones
    {
        [FindsBy(How = How.CssSelector, Using = ".dataTable .header th")]
        [CacheLookup]
        private IList<IWebElement> _header;
        
        private int GetIndexCountryName()
        {
            foreach (var str in _header)
            {
                if (str.Text == "Name")
                    return _header.IndexOf(str);
            }
            return -1;
        }

        public bool CheckZonesOfCountriesOrder()
        {
            var countryIndex = GetIndexCountryName();
            for (var i = 0; i < BaseSelenium.GetCountRowsInTable(); i++)
            {
                var row = BaseSelenium.GetTableRowOfIndex(i);
                BaseSelenium.Click(BaseSelenium.GetElementOfIndexFromRow(row, countryIndex)
                    .FindElement(By.CssSelector("a")));
                if (!Page.AdminEditGeoZone.CheckZonesOrder())
                    return false;
                WebDriver.Driver.Navigate().Back();
            }
            return true;
        }
    }
}