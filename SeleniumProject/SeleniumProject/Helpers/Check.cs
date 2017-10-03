using SeleniumProject.Wrappers;

namespace SeleniumProject.Helpers
{
    public class Check
    {
        public static bool CheckStyleLineThrough(string textStyle)
        {
            return textStyle.Contains("line-through");
        }
        
        public static bool CheckFontBold(string fontWeight)
        {
            var browserType = WebDriver.GetBrowserType();
            switch (browserType)
            {
                case "FirefoxDriver":
                    if (fontWeight == "900") return true;
                    return false;
                case "ChromeDriver":
                    if (fontWeight == "bold") return true;
                    return false;
                case "InternetExplorerDriver":
                    if (fontWeight == "900") return true;
                    return false;
            }
            return false;
        }
    }
}