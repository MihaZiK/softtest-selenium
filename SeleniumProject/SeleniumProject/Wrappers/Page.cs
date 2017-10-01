using OpenQA.Selenium.Support.PageObjects;
using SeleniumProject.Pages;

namespace SeleniumProject.Wrappers
{
    public static class Page
    {
        public static AdminLogin AdminLogin => GetPage<AdminLogin>();

        public static AdminMain AdminMain => GetPage<AdminMain>();

        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(WebDriver.Driver, page);
            return page;
        }
    }
}