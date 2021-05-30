using OpenQA.Selenium;
using POHomeWork1.Tests;

namespace POHomeWork1.Pages
{
    class UserPage : BaseTest
    {
        static readonly string pageUrl = "http://testingchallenges.thetestingmap.org/login/main_page.php";
        private readonly string pageHeader = "Wellcome To Your Personal Road Assitance";
        private readonly By header = By.XPath("//h1[contains(text(), 'Wellcome to your personal road assitance')]");


        public string GetUserPageHeader()
        {
            return driver.FindElement(header).Text;
        }

        public string GetHeaderString()
        {
            return pageHeader;
        }
    }
}
