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
            WebDriver.LoadApplication("http://localhost/litecart/public_html");
        }
        
        [Test]
        public void TestProductStickersCount()
        {
            Assert.IsTrue(Page.Main.StickersCountChecker());
        }
        
        [Test]
        public void TestEqualProductOnMainAndInsidePages()
        {
            var mainProduct = Page.Main.GetCampaignProduct(0);
            var mainRegPriceData = (Dictionary<string, string>) mainProduct["regular_price"];
            var mainCamPriceData = (Dictionary<string, string>) mainProduct["campaign_price"];
            // Цвет и зачеркнутость основной цены на главной странице
            Assert.IsTrue(Helpers.Parse.ParseColor(mainRegPriceData["color"]) == "Grey" &&
                          Helpers.Check.CheckStyleLineThrough(mainRegPriceData["text-decoration"]));
            // Цвет и жирность скидочной цены на главной странице
            Assert.IsTrue(Helpers.Parse.ParseColor(mainCamPriceData["color"]) == "Red" &&
                          Helpers.Check.CheckFontBold(mainCamPriceData["font-weight"]));
            // Размер текста скидочной цены больше основной (главная)
            Assert.IsTrue(Helpers.Compare.CompareSizeinPix(mainRegPriceData["font-size"], mainCamPriceData["font-size"]) 
                          == mainCamPriceData["font-size"]);
            
            Page.Main.ClickCampaignProductByIndex(0);
            var product = Page.Product.GetProductData();
            var regPriceData = (Dictionary<string, string>) product["regular_price"];
            var camPriceData = (Dictionary<string, string>) product["campaign_price"];
            
            // Цвет и зачеркнутость основной цены на странице продукта
            Assert.IsTrue(Helpers.Parse.ParseColor(regPriceData["color"]) == "Grey" &&
                          Helpers.Check.CheckStyleLineThrough(regPriceData["text-decoration"]));
            // Цвет и жирность скидочной цены на странице продукта
            Assert.IsTrue(Helpers.Parse.ParseColor(camPriceData["color"]) == "Red" &&
                          Helpers.Check.CheckFontBold(camPriceData["font-weight"]));
            // Размер текста скидочной цены больше основной (продукт)
            Assert.IsTrue(Helpers.Compare.CompareSizeinPix(regPriceData["font-size"], camPriceData["font-size"]) 
                          == camPriceData["font-size"]);
            
            // Совпадение имени и цен на главной странице и странице продукта
            Assert.IsTrue(mainProduct["name"].Equals(product["name"]));
            Assert.IsTrue(mainRegPriceData["price"] == regPriceData["price"]
                          && mainCamPriceData["price"] == camPriceData["price"]);          
        }
    }
}

