using System;
using System.Threading;
using NUnit.Framework;
using SeleniumProject.Wrappers;

namespace SeleniumProject.Tests
{
    [TestFixture]
    public class ProductAdminTests : BaseTestSuite
    {
        [SetUp]
        public new void SetupTest()
        {
            WebDriver.LoadApplication("http://localhost/litecart/admin/");
        }

        [Test]
        public void TestAddProduct()
        {
            
            Page.AdminLogin.loginAs("admin","admin");
            Page.AdminMain.ClickCatalog();
            // Считываем кол-во строк в таблице перед добавлением товара
            var count = Page.AdminCatalog.GetCountRowsInTable();
            Page.AdminCatalog.ClickAddProduct();
            Page.AddNewProduct.FillName("Doggy");
            Page.AddNewProduct.FillCode();
            Page.AddNewProduct.CheckMale();
            Page.AddNewProduct.FillQuantity("10");
            Page.AddNewProduct.AttachFile();
            Page.AddNewProduct.FillDateFrom("10.06.2017");
            Page.AddNewProduct.FillDateTo("20.12.2017");
            Page.AddNewProduct.ClickStatusEnable();
            Page.AddNewProduct.ClickInformation();
            Page.AddNewProduct.SelectManufacturer("ACME Corp.");
            Page.AddNewProduct.FillHeadTitle("Title");
            Page.AddNewProduct.FillKeywords("Words");
            Page.AddNewProduct.FillShortDescription("Short Description");
            Page.AddNewProduct.FillDescription("Full description");
            Page.AddNewProduct.FillMetaDescription("Meta Description");
            Page.AddNewProduct.ClickPrices();
            Page.AddNewProduct.FillPurchasePrice();
            Page.AddNewProduct.FillPurchasePriceCode();
            Page.AddNewProduct.ClickSave();
            Assert.IsTrue(count + 1 == Page.AdminCatalog.GetCountRowsInTable());
        }
    }
}