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

        public void RegisterUser(string user, string pass, string firstName, string lastName)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(usernameField));
            driver.FindElement(usernameField).Clear();
            driver.FindElement(usernameField).SendKeys(user);
            driver.FindElement(passwordField).Clear();
            driver.FindElement(passwordField).SendKeys(pass);
            driver.FindElement(firstnameField).Clear();
            driver.FindElement(firstnameField).SendKeys(firstName);
            driver.FindElement(lastnameField).Clear();
            driver.FindElement(lastnameField).SendKeys(lastName);
            driver.FindElement(submitButton).Click();
        }

        public string GetProfileText(string value)
        {
            return driver.FindElement(By.XPath("//div[@class='confirm t15']//th[contains(text(),'" + value + "')]")).Text;
        }
    }
}
