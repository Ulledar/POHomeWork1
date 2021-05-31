using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using POHomeWork1.Tests;

namespace POHomeWork1.Pages
{
    class LoginPage : BaseTest
    {
        public static readonly string pageUrl = "http://testingchallenges.thetestingmap.org/login/login.php";

        readonly By _usernameField = By.XPath("//input[@name='username']");
        readonly By _passwordField = By.XPath("//input[@name='password']");
        readonly By _loginButton = By.XPath("//button[contains(text(), 'log in')]");

        readonly WebDriverWait wait = new(driver, new TimeSpan(0, 0, 30));

        public void LoginUser(string user, string pass)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_usernameField));
            IWebElement username = driver.FindElement(_usernameField);
            username.Clear();
            username.SendKeys(user);

            IWebElement password = driver.FindElement(_passwordField);
            password.Clear();
            password.SendKeys(pass);

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_loginButton));
            IWebElement button = driver.FindElement(_loginButton);
            button.Click();
        }
    }
}
