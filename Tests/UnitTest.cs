using CsvHelper;
using NUnit.Framework;
using POHomeWork1.Pages;
using POHomeWork1.Tests;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

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
            logger.Info("user registration");
            MainPage mainPage = new();
            mainPage.RegisterUser(user,pass,first,last);

            logger.Info("checking that user present in the table");
            Assert.Multiple(() =>
            {
                StringAssert.AreEqualIgnoringCase(mainPage.GetProfileText(user), user);
                StringAssert.AreEqualIgnoringCase(mainPage.GetProfileText(pass), pass);
                StringAssert.AreEqualIgnoringCase(mainPage.GetProfileText(first), first);
                StringAssert.AreEqualIgnoringCase(mainPage.GetProfileText(last), last);
            });          
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