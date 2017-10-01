using OpenQA.Selenium.Support.PageObjects;
using SeleniumProject.Pages;
using SeleniumProject.Pages.Admin;

namespace SeleniumProject.Wrappers
{
    public static class Page
    {
        public static AdminLogin AdminLogin => GetPage<AdminLogin>();

        public static AdminMain AdminMain => GetPage<AdminMain>();
        
        public static Main Main => GetPage<Main>();
        
        public static AdminCountries AdminCountries => GetPage<AdminCountries>();
        
        public static AdminEditCountry AdminEditCountry => GetPage<AdminEditCountry>();
        
        public static AdminGeoZones AdminGeoZones => GetPage<AdminGeoZones>();
        
        public static AdminEditGeoZone AdminEditGeoZone => GetPage<AdminEditGeoZone>();
        
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(WebDriver.Driver, page);
            return page;
        }
    }
}