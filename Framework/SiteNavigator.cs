using OpenQA.Selenium;
using POHomeWork1.Pages;
using POHomeWork1.Pages.TestQA;

namespace POHomeWork1.Framework
{
    class SiteNavigator
    {
        public static void NavigateToBHMainPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(MainPage.pageUrl);
        }

        public static void NavigateToBHLoginPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(LoginPage.pageUrl);
        }

        public static void NavToTQARegPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(RegistrationPage.pageUrl);
        }
    }
}
