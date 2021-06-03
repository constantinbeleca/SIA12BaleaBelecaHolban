using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SIA12BaleaBelecaHolban.PageObjectsHelper;
using SIA12BaleaBelecaHolban.NavigationControls;

namespace SIA12BaleaBelecaHolban
{
    [TestClass]
    public class MenSectionTests
    {
        private IWebDriver driver;
        private NotinoMenPage menPage;

        [TestInitialize]
        public void Before()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.notino.ro/");

            var menu = new LoggedOutMenuControl(driver);
            var loginPage = menu.NavigateToLoginPage();
            var homePage = loginPage.LoginApplication("constantin.beleca@yahoo.com", "Constantin1");
            menPage = homePage.loggedInMenuControl.NavigateToMenPage();
        }

        [TestMethod]
        public void Should_reach_perfume_promotions()
        {
            var menSection = menPage.NavigateToMenSection();
            Assert.AreEqual(menSection.LblMen.Text, "Cosmetice barbati");
        }

        [TestCleanup]
        public void After()
        {
            driver.Quit();
        }
    }
}
