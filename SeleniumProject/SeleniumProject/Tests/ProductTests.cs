using System;
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
            WebDriver.LoadApplication("http://localhost/litecart/");
        }
        
        [Test]
        public void TestProductStickersCount()
        {
            Assert.IsTrue(Page.Main.StickersCountChecker());
        }

        [Test]
        public void TestProductsInCart()
        {
            Page.Main.ClickMostPopularProductByIndex(0);
            Page.Product.ClickAddToCart();
            BaseSelenium.BackToPage();
            Page.Main.ClickMostPopularProductByIndex(0);
            Page.Product.ClickAddToCart();
            BaseSelenium.BackToPage();
            Page.Main.ClickMostPopularProductByIndex(0);
            Page.Product.ClickAddToCart();
            Console.ReadLine();
        }
    }
}

