using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumProject.Helpers;
using SeleniumProject.Wrappers;

namespace SeleniumProject.Pages
{
    public class AdminEditGeoZone
    {
        [FindsBy(How = How.CssSelector, Using = ".header th")]
        [CacheLookup]
        private IList<IWebElement> _header;
        
        [FindsBy(How = How.CssSelector, Using = ".dataTable tr:not(.header)")]
        [CacheLookup]
        private IList<IWebElement> _rowsList;
        
        private int GetIndexZone()
        {
            foreach (var str in _header)
            {
                if (str.Text == "Zone")
                    return _header.IndexOf(str);
            }
            return -1;
        }
        
        public bool CheckZonesOrder()
        {
            var indexZone = GetIndexZone();
            var zonesList = new List<string>();
            for (var i = 0; i < _rowsList.Count - 1; i++)
            {
                zonesList.Add(BaseSelenium.GetElementOfIndexFromRow(_rowsList[i], indexZone)
                    .FindElement(By.CssSelector("option[selected='selected']")).Text);
            }
            return Compare.CompareLists(zonesList);
        }
    }
}