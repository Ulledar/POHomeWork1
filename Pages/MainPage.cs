using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using POHomeWork1.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POHomeWork1.Pages
{
    public class MainPage : BaseTest
    {
        public static readonly string pageUrl = "http://testingchallenges.thetestingmap.org/challenge10.php";

        private readonly By usernameField = By.XPath("//input[@name='username']");
        private readonly By passwordField = By.XPath("//input[@name='password']");
        private readonly By firstnameField = By.XPath("//input[@name='firstname']");
        private readonly By lastnameField = By.XPath("//input[@name='lastname']");
        private readonly By submitButton = By.XPath("//input[@value='Submit']");

        readonly WebDriverWait wait = new (driver, new TimeSpan(0, 0, 30));

        public void RegisterUser(string user, string pass, string first, string last)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(usernameField));

            IWebElement userName = driver.FindElement(usernameField);
            userName.Clear();
            userName.SendKeys(user);

            IWebElement password = driver.FindElement(passwordField);
            password.Clear();
            password.SendKeys(pass);

            IWebElement firstName = driver.FindElement(firstnameField);
            firstName.Clear();
            firstName.SendKeys(first);

            IWebElement lastName = driver.FindElement(lastnameField);
            lastName.Clear();
            lastName.SendKeys(last);

            driver.FindElement(submitButton).Click();
        }

        public string GetProfileText(string value)
        {
            return driver.FindElement(By.XPath("//div[@class='confirm t15']//th[contains(text(),'" + value + "')]")).Text;
        }
    }
}
