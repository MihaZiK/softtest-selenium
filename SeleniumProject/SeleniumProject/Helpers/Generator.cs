using System;

namespace SeleniumProject.Helpers
{
    public class Generator
    {
        public static string EmailGenerator()
        {
            return "TestEmail" + new Random().Next(10000, 99999)+"@test.com";
        }
        
        public static string PhoneGenerator()
        {
            return "+7923424" + new Random().Next(100000, 999999);
        }
    }
}