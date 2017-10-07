using OpenQA.Selenium.Support.PageObjects;
using SeleniumProject.Pages;
using SeleniumProject.Pages.Admin;

namespace SeleniumProject.Wrappers
{
    public static class Page
    {
        public static AdminLogin AdminLogin
        {
            get { return GetPage<AdminLogin>(); }
        }

        public static AdminMain AdminMain
        {
            get { return GetPage<AdminMain>(); }
        }

        public static Main Main
        {
            get { return GetPage<Main>(); }
        }

        public static AdminEditCountry AdminEditCountry
        {
            get { return GetPage<AdminEditCountry>(); }
        }

        public static AdminGeoZones AdminGeoZones
        {
            get { return GetPage<AdminGeoZones>(); }
        }

        public static AdminCountries AdminCountries
        {
            get { return GetPage<AdminCountries>(); }
        }

        public static AdminEditGeoZone AdminEditGeoZone
        {
            get { return GetPage<AdminEditGeoZone>(); }
        }

        public static Product Product
        {
            get { return GetPage<Product>(); }
        }
        
        public static CreateAccount CreateAccount
        {
            get { return GetPage<CreateAccount>(); }
        }
        
        public static AdminCatalog AdminCatalog
        {
            get { return GetPage<AdminCatalog>(); }
        }
        
        public static AddNewProduct AddNewProduct
        {
            get { return GetPage<AddNewProduct>(); }
        }
        
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(WebDriver.Driver, page);
            return page;
        }
    }
}