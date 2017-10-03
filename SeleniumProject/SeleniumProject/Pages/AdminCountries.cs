using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumProject.Helpers;
using SeleniumProject.Wrappers;

namespace SeleniumProject.Pages
{
    public class AdminCountries
    {
        [FindsBy(How = How.CssSelector, Using = ".dataTable .header th")]
        [CacheLookup]
        private IList<IWebElement> _header;
        
        [FindsBy(How = How.CssSelector, Using = ".dataTable .row")]
        [CacheLookup]
        private IList<IWebElement> _rowsList;

        private int GetIndexCountryName()
        {
            foreach (var str in _header)
            {
                if (str.Text == "Name")
                    return _header.IndexOf(str);
            }
            return -1;
        }
        
        private int GetIndexZones()
        {
            foreach (var str in _header)
            {
                if (str.Text == "Zones")
                    return _header.IndexOf(str);
            }
            return -1;
        }

        public bool CheckCountriesOrder()
        {
            var nameIndex = GetIndexCountryName();
            var countriesList = _rowsList.Select(row => row.FindElements(By.CssSelector("td")))
                .Select(strList => strList[nameIndex].Text).ToList();

            return Compare.CompareLists(countriesList);
        }

        public bool CheckZonesAndCountriesOrder()
        {
            var indexZones = GetIndexZones();
            var indexName = GetIndexCountryName();
            var countriesList = new List<string>();
            // Проходим по всему списку таблицы стран
            for (var i = 0; i < BaseSelenium.GetCountRowsInTable(); i++)
            {
                // Выделяем страну и кол-во зон в стране
                var row = BaseSelenium.GetTableRowOfIndex(i);
                var zonesCount = BaseSelenium.GetElementOfIndexFromRow(row, indexZones).Text;
                var country = BaseSelenium.GetElementOfIndexFromRow(row, indexName).Text;
                countriesList.Add(country);
                // Заходим в страну и проверяем порядок зон
                if (Convert.ToInt32(zonesCount) == 0) continue;
                BaseSelenium.Click(BaseSelenium.GetElementOfIndexFromRow(row, indexName)
                    .FindElement(By.CssSelector("a")));
                if (!Page.AdminEditCountry.CheckZonesOrder())
                {
                    return false;
                }
                WebDriver.Driver.Navigate().Back();
            }
            return Compare.CompareLists(countriesList);
        }
    }
}