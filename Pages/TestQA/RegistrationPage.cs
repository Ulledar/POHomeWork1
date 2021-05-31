using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using POHomeWork1.Framework;
using POHomeWork1.Tests;
using System;

namespace POHomeWork1.Pages.TestQA
{
    class RegistrationPage : BaseTest
    {
        public static readonly string pageUrl = "https://demoqa.com/automation-practice-form";

        readonly By _firstnameField = By.Id("firstName");
        readonly By _lastnameField = By.Id("lastName");
        readonly By _emailField = By.Id("userEmail");
        readonly By _maleGender = By.XPath("//label[@for='gender-radio-1']");
        readonly By _femaleGender = By.XPath("//label[@for='gender-radio-2']");
        readonly By _otherGender = By.XPath("//label[@for='gender-radio-3']");
        readonly By _maleGenderButton = By.Id("gender-radio-1");
        readonly By _femaleGenderButton = By.Id("gender-radio-2");
        readonly By _otherGenderButton = By.Id("gender-radio-3");
        readonly By _phoneNumberField = By.Id("userNumber");
        readonly By _birthDateField = By.Id("dateOfBirthInput");
        readonly By _subjectField = By.XPath("//div[@class='subjects-auto-complete__value-container subjects-auto-complete__value-container--is-multi css-1hwfws3']");

        readonly WebDriverWait wait = new(driver, new TimeSpan(0, 0, 30));

        public void FillFirstName(string firstname)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_firstnameField));
            IWebElement first = driver.FindElement(_firstnameField);
            first.Clear();
            first.SendKeys(firstname);
        }

        public void FillLastName(string lastname)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_lastnameField));
            IWebElement last = driver.FindElement(_lastnameField);
            last.Clear();
            last.SendKeys(lastname);
        }

        public void FillEmail(string email)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_emailField));
            IWebElement last = driver.FindElement(_emailField);
            last.Clear();
            last.SendKeys(email);
        }

        public void ChooseGender(string genderType)
        {
            if (genderType == "male") driver.FindElement(_maleGender).Click();
            if (genderType == "female") driver.FindElement(_femaleGender).Click();
            if (genderType == "other") driver.FindElement(_otherGender).Click();
        }

        public static string GetRandomGender(int randomNumber)
        {
            switch (randomNumber)
            {
                case 1:
                    return "male";

                case 2:
                    return "female";

                case 3:
                    return "other";

                default:
                    throw new Exception("Something wrong!");
            }
        }

        public void FillRandomPhoneNumber()
        {
            string number = null;
            for (int i = 0; i <10; i++) number = number + Utils.RandomNumber(0, 9).ToString();
            
            IWebElement phoneNum = driver.FindElement(_phoneNumberField);
            phoneNum.Clear();
            phoneNum.SendKeys(number);
        }

        public void ChooseRandomBirthDate()
        {
            driver.FindElement(_birthDateField).Click();

            driver.FindElement(By.CssSelector("select.react-datepicker__month-select")).Click();
            driver.FindElement(By.XPath("//option[@value='" + Utils.RandomNumber(0,11).ToString() + "']")).Click();

            driver.FindElement(By.CssSelector("select.react-datepicker__year-select")).Click();
            driver.FindElement(By.XPath("//option[@value='"+ Utils.RandomNumber(1900,2100).ToString() +"']")).Click();

            driver.FindElement(By.XPath("//div[@class='react-datepicker__week']//div[contains(text(),"+Utils.RandomNumber(1,31).ToString()+")]")).Click();
        }

        public void ChooseSubject()
        {
            IWebElement field = driver.FindElement(_subjectField);
            field.Clear();
            field.SendKeys("English");
            field.SendKeys(Keys.Enter);
        }
    }
}
