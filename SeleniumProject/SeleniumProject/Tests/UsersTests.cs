using NUnit.Framework;
using SeleniumProject.Wrappers;

namespace SeleniumProject.Tests
{
    [TestFixture]
    public class Users : BaseTestSuite
    {
        [SetUp]
        public new void SetupTest()
        {
            WebDriver.LoadApplication("http://localhost/litecart/public_html/");
        }
        
        [Test]
        public void TestCreateAccount()
        {
            string email = Helpers.Generator.EmailGenerator();
            string phone = Helpers.Generator.PhoneGenerator();
            Page.Main.ClickRegistration();
            Page.CreateAccount.Registration("Tester",
                "Tester",
                "Test Street",
                "63212",
                "TestCity",
                "United States",
                "Colorado",
                email,
                phone,
                "123QWEasd"
                );
            Page.Main.ClickLogout();
            Page.Main.Login(email,"123QWEasd");
            Page.Main.ClickLogout();
        }
    }
}