using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using POHomeWork1.Pages;
using System;

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
            logger.Info("log4net initialized");
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl(MainPage.pageUrl);
            logger.Info("Test started");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
