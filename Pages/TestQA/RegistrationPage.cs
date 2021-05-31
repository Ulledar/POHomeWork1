using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using POHomeWork1.Framework;
using POHomeWork1.Tests;
using System;
using System.IO;

namespace POHomeWork1.Pages.TestQA
{
    class RegistrationPage : BaseTest
    {
        public static readonly string pageUrl = "https://demoqa.com/automation-practice-form";

        #region Locators
        readonly By _firstnameField = By.Id("firstName");
        readonly By _lastnameField = By.Id("lastName");
        readonly By _emailField = By.Id("userEmail");
        readonly By _maleGender = By.XPath("//label[@for='gender-radio-1']");
        readonly By _femaleGender = By.XPath("//label[@for='gender-radio-2']");
        readonly By _otherGender = By.XPath("//label[@for='gender-radio-3']");
        readonly By _phoneNumberField = By.Id("userNumber");
        readonly By _birthDateField = By.Id("dateOfBirthInput");
        readonly By _subjectField = By.Id("subjectsInput");
        readonly By _hobbieSport = By.XPath("//label[@for='hobbies-checkbox-1']");
        readonly By _hobbieRead = By.XPath("//label[@for='hobbies-checkbox-2']");
        readonly By _hobbieMusic = By.XPath("//label[@for='hobbies-checkbox-3']");
        readonly By _uploadPicture = By.Id("uploadPicture");
        readonly By _submitButton = By.Id("submit");
        readonly By _currentAddressField = By.Id("currentAddress");
        readonly By _selectState = By.Id("react-select-3-input");
        readonly By _selectCity = By.Id("react-select-4-input");
        readonly By _closeCompletedForm = By.Id("closeLargeModal");

        #endregion

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
            driver.FindElement(By.XPath("//option[@value='" + Utils.RandomNumber(0,12).ToString() + "']")).Click();

            driver.FindElement(By.CssSelector("select.react-datepicker__year-select")).Click();
            driver.FindElement(By.XPath("//option[@value='"+ Utils.RandomNumber(1900,2022).ToString() +"']")).Click();

            driver.FindElement(By.XPath("//div[@class='react-datepicker__week']//div[contains(text()," + Utils.RandomNumber(1,31).ToString() + ")]")).Click();
        }

        public void ChooseSubject()
        {
            IWebElement field = driver.FindElement(_subjectField);
            field.Clear();
            field.SendKeys("English");
            field.SendKeys(Keys.Enter);
        }

        public void ChooseRandomHobbies()
        {
            if (Utils.RandomNumber(0, 2) == 1) driver.FindElement(_hobbieSport).Click();
            if (Utils.RandomNumber(0, 2) == 1) driver.FindElement(_hobbieRead).Click();
            if (Utils.RandomNumber(0, 2) == 1) driver.FindElement(_hobbieMusic).Click();
        }

        public void UploadPicture()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string picturePath = path + @"\Resources\TestPictures\" + Utils.RandomNumber(1, 4) + ".jpg";
            driver.FindElement(_uploadPicture).SendKeys(picturePath);
        }

        public void FillAddressFild(string address)
        {
            IWebElement curAddress = driver.FindElement(_currentAddressField);
            curAddress.Clear();
            curAddress.SendKeys(address);
        }

        public void SelectCity()
        {
            IWebElement state = driver.FindElement(_selectState);
            state.SendKeys("Uttar Pradesh");
            state.SendKeys(Keys.Enter);

            IWebElement city = driver.FindElement(_selectCity);
            city.SendKeys("Merrut");
            city.SendKeys(Keys.Enter);
        }

        public void PressSubmitPutton()
        {
            driver.FindElement(_submitButton).Click();
        }
    }
}