using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumProject.Helpers;

namespace SeleniumProject.Pages
{
    public class AdminEditCountry
    {
        [FindsBy(How = How.CssSelector, Using = ".dataTable .header th")]
        [CacheLookup]
        private IList<IWebElement> _header;
        
        [FindsBy(How = How.CssSelector, Using = ".dataTable .row")]
        [CacheLookup]
        private IList<IWebElement> _rowsList;
        
        private int GetIndexZoneName()
        {
            foreach (var str in _header)
            {
                if (str.Text == "Name")
                    return _header.IndexOf(str);
            }
            return -1;
        }
        
        public bool CheckZonesOrder()
        {
            var nameIndex = GetIndexZoneName();
            var zonesList = _rowsList.Select(row => row.FindElements(By.CssSelector("td")))
                .Select(strList => strList[nameIndex].Text).ToList();

            return CompareHelper.CompareLists(zonesList);
        }
    }
}