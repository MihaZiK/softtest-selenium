using System;
using System.Collections.Generic;
using OpenQA.Selenium.Internal;
using SeleniumProject.Wrappers;

namespace SeleniumProject.Helpers
{
    public class Parse
    {
        public static string ParseColor(string rgb)
        {
            var browserType = WebDriver.GetBrowserType();
            var colors = new Dictionary<string, int>();
            switch (browserType)
            {
                case "FirefoxDriver":
                    colors = ParseColorFirefox(rgb);
                    if (CheckRedColor(colors)) return "Red";
                    else if (CheckGreyColor(colors)) return "Grey";
                    else return "Unknown";
                case "ChromeDriver":
                    colors = ParseColorIeChrome(rgb);
                    if (CheckRedColor(colors)) return "Red";
                    else if (CheckGreyColor(colors)) return "Grey";
                    else return "Unknown";
                case "InternetExplorerDriver":
                    colors = ParseColorIeChrome(rgb);
                    if (CheckRedColor(colors)) return "Red";
                    else if (CheckGreyColor(colors)) return "Grey";
                    else return "Unknown";
            }
            return "Unknown";
        }

        private static Dictionary<string, int> ParseColorFirefox(string rgb)
        {
            var colors = new Dictionary<string, int>();
            var rgbSplit = rgb.Split(',');
            colors.Add("red", Convert.ToInt32(rgbSplit[0].Substring(4, rgbSplit[0].Length - 4)));
            colors.Add("green", Convert.ToInt32(rgbSplit[1].Substring(1, rgbSplit[1].Length -1)));
            colors.Add("blue", Convert.ToInt32(rgbSplit[2].Substring(1, rgbSplit[2].Length - 2)));
            return colors;
        }
        
        private static Dictionary<string, int> ParseColorIeChrome(string rgb)
        {
            var colors = new Dictionary<string, int>();
            var rgbSplit = rgb.Split(',');
            colors.Add("red", Convert.ToInt32(rgbSplit[0].Substring(5, rgbSplit[0].Length - 5)));
            colors.Add("green", Convert.ToInt32(rgbSplit[1].Substring(1, rgbSplit[1].Length -1)));
            colors.Add("blue", Convert.ToInt32(rgbSplit[2].Substring(1, rgbSplit[2].Length - 1)));
            return colors;
        }
        
        private static bool CheckRedColor(IReadOnlyDictionary<string, int> colors)
        {
            return colors["red"] != 0 && colors["green"] == 0 && colors["blue"] == 0;
        }
        
        private static bool CheckGreyColor(IReadOnlyDictionary<string, int> colors)
        {
            return colors["red"] == colors["green"] && colors["green"] == colors["blue"];
        }

        public static double ParseSizeInPix(string size)
        {
            size = size.Replace(".", ",");
            return Convert.ToDouble(size.Substring(0, size.IndexOf("p", StringComparison.Ordinal)));
        }
    }
}