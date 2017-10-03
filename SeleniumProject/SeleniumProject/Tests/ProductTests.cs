using System;
using System.Collections.Generic;
using NUnit.Framework;
using SeleniumProject.Wrappers;

namespace SeleniumProject.Tests
{
    [TestFixture]
    public class ProductTests : BaseTestSuite
    {
        [SetUp]
        public new void SetupTest()
        {
            base.SetupTest();
            WebDriver.LoadApplication("http://localhost/litecart");
        }
        
        [Test]
        public void TestProductStickersCount()
        {
            Assert.IsTrue(Page.Main.StickersCountChecker());
        }
        
        // 
        [Test]
        public void TestDuck()
        {
            var product = Page.Main.GetCampaignProduct(0);
            var regPriceData = (Dictionary<string, string>) product["regular_price"];
            var camPriceData = (Dictionary<string, string>) product["campaign_price"];
            // Цвет и зачеркнутость основной цены на главной
            Assert.IsTrue(Helpers.Parse.ParseColor(regPriceData["color"]) == "Grey" &&
                          Helpers.Check.CheckStyleLineThrough(regPriceData["text-decoration"]));
            // Цвет и жирность скидочной цены на главной
            Assert.IsTrue(Helpers.Parse.ParseColor(camPriceData["color"]) == "Red" &&
                          Helpers.Check.CheckFontBold(camPriceData["font-weight"]));
            // Размер текста скидочной цены больше основной
            Assert.IsTrue(Helpers.Compare.CompareSizeinPix(regPriceData["font-size"], camPriceData["font-size"]) 
                          == camPriceData["font-size"]);
            
        }
    }
}