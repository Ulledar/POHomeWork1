using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using POHomeWork1.Tests;
using System;

namespace POHomeWork1.Pages
{
    class MainPage : BaseTest
    {
        public static readonly string pageUrl = "http://testingchallenges.thetestingmap.org/challenge10.php";

        readonly By _usernameField = By.XPath("//input[@name='username']");
        readonly By _passwordField = By.XPath("//input[@name='password']");
        readonly By _firstnameField = By.XPath("//input[@name='firstname']");
        readonly By _lastnameField = By.XPath("//input[@name='lastname']");
        readonly By _submitButton = By.XPath("//input[@value='Submit']");

        readonly WebDriverWait wait = new (driver, new TimeSpan(0, 0, 30));

        public void RegisterUser(string user, string pass, string first, string last)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_usernameField));

            IWebElement userName = driver.FindElement(_usernameField);
            userName.Clear();
            userName.SendKeys(user);

            IWebElement password = driver.FindElement(_passwordField);
            password.Clear();
            password.SendKeys(pass);

            IWebElement firstName = driver.FindElement(_firstnameField);
            firstName.Clear();
            firstName.SendKeys(first);

            IWebElement lastName = driver.FindElement(_lastnameField);
            lastName.Clear();
            lastName.SendKeys(last);

            driver.FindElement(_submitButton).Click();
        }

        public string GetProfileText(string value)
        {
            return driver.FindElement(By.XPath("//div[@class='confirm t15']//th[contains(text(),'" + value + "')]")).Text;
        }
    }
}
