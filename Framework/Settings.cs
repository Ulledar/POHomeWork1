using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using System;

namespace POHomeWork1.Framework
{
    class Settings
    {
        public static IWebDriver GetDriver(string browserType)
        {
            switch (browserType)
            {
                case "chrome":
                    return new ChromeDriver(@"Resources\Drivers\");

                case "firefox":
                    return new FirefoxDriver(@"Resources\Drivers\");

                case "opera":
                    return new OperaDriver(@"Resources\Drivers\");

                case "edge":
                    return new EdgeDriver(@"Resources\Drivers\");

                default:
                    throw new Exception("Unknown browser type!");
            }
        }
    }
}
