using CsvHelper;
using NUnit.Framework;
using POHomeWork1.Pages;
using POHomeWork1.Tests;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using POHomeWork1.Framework;
using System.Threading;

namespace POHomeWork1
{
    public class UnitTest : BaseTest
    {
        [Test]
        [Author("AlexGrech")]
        [Category("Test case ID: 1")]
        [TestCaseSource("GetTestData")]
        public void Test1(string user, string pass, string first, string last)
        {
            logger.Info("Test started. Navigate to main page");
            SiteNavigator.NavigateToMainPage(driver);

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
            SiteNavigator.NavigateToLoginPage(driver);

            logger.Info("Login user");
            LoginPage loginPage = new();
            loginPage.LoginUser(user, pass);

            logger.Info("Checking that login was successful");
            UserPage userPage = new();
            Assert.AreEqual(userPage.GetUserPageHeader(), userPage.GetHeaderString(), "Login was unsuccessful");
        }

        private static IEnumerable<string[]> GetTestData()
        {
            using (var csv = new CsvReader(new StreamReader(@"Resources/NewUsers.csv"), CultureInfo.InvariantCulture))
            {
                while (csv.Read())
                {
                    string user = csv[0];
                    string pass = csv[1];
                    string first = csv[2];
                    string last = csv[3];

                    yield return new[] { user, pass, first, last };
                }
            }
        }
    }
}