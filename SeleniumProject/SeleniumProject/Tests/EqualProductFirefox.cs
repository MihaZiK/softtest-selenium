using System.Collections.Generic;
using NUnit.Framework;
using SeleniumProject.Wrappers;

namespace SeleniumProject.Tests
{
    [TestFixture]
    public class EqualProductFirefox : BaseTestSuite
    {
        [SetUp]
        public void SetupTest()
        {
            WebDriver.InitBrowser("Firefox");
            WebDriver.LoadApplication("http://localhost/litecart/public_html");
        }       
                  
        [Test]
        public void TestEqualProductOnMainAndInsidePages()
        {
            var mainProduct = Page.Main.GetCampaignProduct(0);
            var mainRegPriceData = (Dictionary<string, string>) mainProduct["regular_price"];
            var mainCamPriceData = (Dictionary<string, string>) mainProduct["campaign_price"];
            // Цвет и зачеркнутость основной цены на главной странице
            Assert.IsTrue(Helpers.Parse.ParseColor(mainRegPriceData["color"]) == "Grey" &&
                          Helpers.Check.CheckStyleLineThrough(mainRegPriceData["text-decoration"])
                          ,"Неверный стиль основной цены на главной странице. Color: {0}, line-Through:{1}"
                          , Helpers.Parse.ParseColor(mainRegPriceData["color"])
                          , Helpers.Check.CheckStyleLineThrough(mainRegPriceData["text-decoration"]));
            // Цвет и жирность скидочной цены на главной странице
            Assert.IsTrue(Helpers.Parse.ParseColor(mainCamPriceData["color"]) == "Red" &&
                          Helpers.Check.CheckFontBold(mainCamPriceData["font-weight"])
                          ,"Неверный стиль цены со скидкой на главной странице. Color: {0}, font-weight:{1}"
                          , Helpers.Parse.ParseColor(mainCamPriceData["color"])
                          , Helpers.Check.CheckFontBold(mainCamPriceData["font-weight"]));
            // Размер текста скидочной цены больше основной (главная)
            Assert.IsTrue(Helpers.Compare.CompareSizeinPix(mainRegPriceData["font-size"], mainCamPriceData["font-size"]) 
                          == mainCamPriceData["font-size"]
                          , "Текст цены со скидкой не больше основной. осн.: {0}, скидка:{1}"
                          , mainRegPriceData["font-size"]
                          , mainCamPriceData["font-size"]);
            
            Page.Main.ClickCampaignProductByIndex(0);
            var product = Page.Product.GetProductData();
            var regPriceData = (Dictionary<string, string>) product["regular_price"];
            var camPriceData = (Dictionary<string, string>) product["campaign_price"];
            
            // Цвет и зачеркнутость основной цены на странице продукта
            Assert.IsTrue(Helpers.Parse.ParseColor(regPriceData["color"]) == "Grey" &&
                          Helpers.Check.CheckStyleLineThrough(regPriceData["text-decoration"])
                          ,"Неверный стиль основной цены на странице продукта. Color: {0}, line-Through:{1}"
                          , Helpers.Parse.ParseColor(camPriceData["color"])
                          , Helpers.Check.CheckFontBold(camPriceData["font-weight"]));
            // Цвет и жирность скидочной цены на странице продукта
            Assert.IsTrue(Helpers.Parse.ParseColor(camPriceData["color"]) == "Red" &&
                          Helpers.Check.CheckFontBold(camPriceData["font-weight"])
                          ,"Неверный стиль цены со скидкой на странице продукта. Color: {0}, font-weight:{1}"
                          , Helpers.Parse.ParseColor(camPriceData["color"])
                          , Helpers.Check.CheckFontBold(camPriceData["font-weight"]));
            // Размер текста скидочной цены больше основной (продукт)
            Assert.IsTrue(Helpers.Compare.CompareSizeinPix(regPriceData["font-size"], camPriceData["font-size"]) 
                          == camPriceData["font-size"]
                          , "Текст цены со скидкой не больше основной. осн.: {0}, скидка:{1}"
                          , regPriceData["font-size"]
                          , camPriceData["font-size"]);
            
            // Совпадение имени и цен на главной странице и странице продукта
            Assert.IsTrue(mainProduct["name"].Equals(product["name"])
                          , "Различные имена товара на главной и перс. страницах. main: {0}, pers:{1}"
                          , mainProduct["name"]
                          , product["name"]);
            Assert.IsTrue(mainRegPriceData["price"] == regPriceData["price"]
                          ,"Различается основная цена на главной и перс. страницах. main:{0}, pers:{1}"
                          ,mainRegPriceData["price"]
                          ,regPriceData["price"]);
            Assert.IsTrue(mainCamPriceData["price"] == camPriceData["price"]
                          ,"Различается цена со скидкой на главной и перс. страницах. main:{0}, pers:{1}"
                          ,mainCamPriceData["price"]
                          ,camPriceData["price"]);            
        }
    }
}