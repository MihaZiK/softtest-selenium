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

        public static string ProductCodeGenerator()
        {
            return "p" + new Random().Next(1000, 9999);
        }
    }
}