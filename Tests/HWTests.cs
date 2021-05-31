using CsvHelper;
using NUnit.Framework;
using POHomeWork1.Pages;
using POHomeWork1.Tests;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using POHomeWork1.Framework;
using POHomeWork1.Pages.TestQA;
using System.Threading;

namespace POHomeWork1
{
    public class HWTests : BaseTest
    {
        
        [Test]
        [Author("AlexGrech")]
        [Category("Test case ID: 1")]
        [TestCaseSource("GetLoginTestData")]
        [Description("Creating user and checking his exist into the table and login possibility")]
        public void BugHuntTest(string user, string pass, string first, string last, string testcaseId)
        {
            logger.Info("Test started. Navigate to main page");
            SiteNavigator.NavigateToBHMainPage(driver);

            logger.Info("User registration");
            MainPage mainPage = new();
            mainPage.RegisterUser(user,pass,first,last);

            logger.Info("Checking that user presents in the table");
            Assert.Multiple(() =>
            {
                Assert.AreEqual(mainPage.GetProfileText(user), user, "No such Username");
                Assert.AreEqual(mainPage.GetProfileText(pass), pass, "No such Password");
                Assert.AreEqual(mainPage.GetProfileText(first), first, "No such Name");
                Assert.AreEqual(mainPage.GetProfileText(last), last, "No such Last Name");
            });

            logger.Info("Navigate to login page");
            SiteNavigator.NavigateToBHLoginPage(driver);

            logger.Info("Logining user");
            LoginPage loginPage = new();
            loginPage.LoginUser(user, pass);

            logger.Info("Checking that login was successful");
            UserPage userPage = new();
            Assert.Multiple(() =>
            {
                Assert.AreEqual(userPage.GetUserPageHeader(), userPage.GetHeaderString(), "Login was unsuccessful");
                Assert.AreEqual(driver.Url, userPage.GetUserPageUrl(), "User url is different");
            });
            
            logger.Info("Making a screenshot");
            Utils.MakeScreenshot(testcaseId);
        }

        [Ignore("q")]
        [Test]
        [Author("AlexGrech")]
        [Category("Test case ID: 2")]
        [Description("Positive test")]
        public void ToolsQaTest()
        {
            RegistrationPage regPage = new();

            logger.Info("Test started. Navigate to registration page");
            SiteNavigator.NavToTQARegPage(driver);

            logger.Info("Fill name, last name and email fields");
            regPage.FillFirstName("John");
            regPage.FillLastName("Wick");
            regPage.FillEmail("boogieman@gmail.com");

            logger.Info("Choosing gender by random");
            regPage.ChooseGender(RegistrationPage.GetRandomGender(Utils.RandomNumber(1, 3)));

            logger.Info("Generate random phone number");
            regPage.FillRandomPhoneNumber();

            logger.Info("Choosing random birth date");
            regPage.ChooseRandomBirthDate();

            
            logger.Info("Choosing subject");
            regPage.ChooseSubject();

            logger.Info("Random hobbies");
            regPage.ChooseRandomHobbies();

            Thread.Sleep(5000);
        }

        private static IEnumerable<string[]> GetLoginTestData()
        {
            using var csv = new CsvReader(new StreamReader(@"Resources/NewUsers.csv"), CultureInfo.InvariantCulture);
            while (csv.Read())
            {
                string user = csv[0];
                string pass = csv[1];
                string first = csv[2];
                string last = csv[3];
                string testId = csv[4];

                yield return new[] { user, pass, first, last, testId };
            }
        }
    }
}