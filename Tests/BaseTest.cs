using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using POHomeWork1.Framework;

namespace POHomeWork1.Tests
{
    public class BaseTest
    {
        protected static IWebDriver driver;
        protected ILog logger;

        [OneTimeSetUp]
        public void SetUp()
        {
            logger = LogManager.GetLogger(GetType());
            driver = Settings.GetDriver("chrome");
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }

        [TearDown]
        public void TearDown()
        {
            logger.Info("Making a screenshot");
            Utils.MakeScreenshot(HWTests.testCaseName);
        }
    }
}
