using OpenQA.Selenium;
using POHomeWork1.Pages;

namespace POHomeWork1.Framework
{
    class SiteNavigator
    {
        public static void NavigateToMainPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(MainPage.pageUrl);
        }

        public static void NavigateToLoginPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(LoginPage.pageUrl);
        }

    }
}
