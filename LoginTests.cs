using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SIA12BaleaBelecaHolban.PageObjectsHelper;

namespace SIA12BaleaBelecaHolban
{
    [TestClass]
    public class LoginTests
    {
        private IWebDriver driver;
        private NotinoLoginPage loginPage;

        [TestInitialize]
        public void Before() 
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.notino.ro/");
            driver.FindElement(By.ClassName("_1W8FHoGkAK1-vShN-OLaxj")).Click();
            loginPage = new NotinoLoginPage(driver);
        }

        [TestCleanup]
        public void After() 
        {
            driver.Quit();
        }

        [TestMethod]
        public void Should_login_successfully_with_valid_credentials()
        {
            var homePage = loginPage.LoginApplication("constantin.beleca@yahoo.com", "Constantin1");
            Assert.AreEqual(homePage.loggedInMenuControl.LblEmail.Text, "constantin.beleca@yahoo.com");
        }

        [TestMethod]
        public void Should_fail_login_with_invalid_credentials() 
        {
            loginPage.LoginApplication("qwerty@qwerty.qwerty", "qwerty");
            Assert.AreEqual(loginPage.LblLoginFailed.Text, "Login incorect - email/parola greșite.");
        }
    }
}
