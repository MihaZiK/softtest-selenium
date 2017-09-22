namespace TestsCardPayments.Wrappers
{
    using OpenQA.Selenium.Support.PageObjects;
    
    using SeleniumProject.Pages;

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
        
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(WebDriver.Driver, page);
            return page;
        }
    }
}