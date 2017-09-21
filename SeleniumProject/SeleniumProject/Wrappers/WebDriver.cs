using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace TestsCardPayments.Wrappers
{
    public class WebDriver
    {
        public static IWebDriver Driver { get; private set; }

        public static WebDriverWait Wait { get; private set; }

        public static void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    if (Driver == null)
                    {
                        Driver = new FirefoxDriver();
                    }
                    break;
                case "IE":
                    if (Driver == null)
                    {
                        Driver = new InternetExplorerDriver();
                    }
                    break;
                case "Chrome":
                    if (Driver == null)
                    {
                        Driver = new ChromeDriver();
                    }
                    break;
                default:
                    throw new InvalidOperationException("Unknown browser type");
            }   
            Wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 15));
        }

        public static void LoadApplication(string url)
        {
            Driver.Url = url;
        }

        public static void CloseDriver()
        {
                Driver.Close();
                Driver.Quit();
        }
    }
}