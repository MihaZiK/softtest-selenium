using System;

namespace SeleniumProject.Helpers
{
    public class Generator
    {
        public static string EmailGenerator()
        {
            return "TestEmail" + new Random(10000).Next()+"@test.com";
        }
        
        public static string PhoneGenerator()
        {
            return "+7923424" + new Random(100000).Next();
        }
    }
}