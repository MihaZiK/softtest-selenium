namespace SeleniumProject.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using TestsCardPayments.Wrappers;
    
    public class AdminLogin
    {
        [FindsBy(How = How.Name, Using = "username")]
        [CacheLookup]
        private IWebElement _username;
        
        [FindsBy(How = How.Name, Using = "password")]
        [CacheLookup]
        private IWebElement _password;
        
        [FindsBy(How = How.Name, Using = "login")]
        [CacheLookup]
        private IWebElement _login;
        
        public void FillUsername(string username)
        {
            BaseSelenium.FillText(_username, username);
        }
        
        public void FillPassword(string password)
        {
            BaseSelenium.FillText(_password, password);
        }

        public void ClickLogin()
        {
            BaseSelenium.Click(_login);
        }

        public void loginAs(string username, string password)
        {
            FillUsername(username);
            FillPassword(password);
            ClickLogin();
        }
    }
}