using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumProject.Wrappers;

namespace SeleniumProject.Pages.Admin
{
    public class AdminMain
    {
        [FindsBy(How = How.CssSelector, Using = "a[href*='logout.php']")]
        [CacheLookup]
        private IWebElement _logoutButton;
        
        [FindsBy(How = How.CssSelector, Using = "#app- a[href*=countries]")]
        [CacheLookup]
        private IWebElement _countriesButton;
        
        [FindsBy(How = How.CssSelector, Using = "#app- a[href*=geo_zones]")]
        [CacheLookup]
        private IWebElement _geoZonesButton;
        
        [FindsBy(How = How.CssSelector, Using = "#app- > a[href*=catalog]")] 
        [CacheLookup]
        private IWebElement _catalogButton;

        public void ClickLogout()
        {
            BaseSelenium.Click(_logoutButton);
        }

        public void ClickCountries()
        {
            BaseSelenium.Click(_countriesButton);
        }
        
        public void ClickGeoZones()
        {
            BaseSelenium.Click(_geoZonesButton);
        }
        
        public void ClickCatalog()
        {
            BaseSelenium.Click(_catalogButton);
        }
        
        public bool MenuChecker()
        {
            // Идем по списку всех элементов меню
            for (var i = 0; i < WebDriver.Driver.FindElements(By.Id("app-")).Count; i++)
            {
                var menuItem = WebDriver.Driver.FindElements(By.Id("app-"))[i];    
                BaseSelenium.Click(menuItem);
                
                // Если есть подменю, то проходим и по нему
                if (BaseAsserts.AreElementsPresent(By.CssSelector("ul.docs li")))
                {
                    for (var j = 0; j < WebDriver.Driver.FindElements(By.CssSelector("ul.docs li")).Count; j++)
                    {
                        menuItem = WebDriver.Driver.FindElements(By.CssSelector("ul.docs li"))[j]; 
                        BaseSelenium.Click(menuItem);
                        if (!BaseAsserts.IsElementPresent(By.CssSelector("h1")))
                            return false;
                    }
                }
                if (!BaseAsserts.IsElementPresent(By.CssSelector("h1")))
                    return false;
            }
            return true;
        }
    }
}