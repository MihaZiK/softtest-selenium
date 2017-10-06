using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SeleniumProject.Wrappers;

namespace SeleniumProject.Tests
{
    [TestFixture]
    public class Users : BaseTestSuite
    {
        [SetUp]
        public new void SetupTest()
        {
            WebDriver.LoadApplication("http://localhost/litecart/");
        }
        
        [Test]
        public void createAccount()
        {
            Page.Main.ClickRegistration();
            Page.CreateAccount.Registration();
            Console.ReadLine();
        }
    }
}