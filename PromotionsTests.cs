using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SIA12BaleaBelecaHolban.PageObjectsHelper;
using SIA12BaleaBelecaHolban.NavigationControls;

namespace SIA12BaleaBelecaHolban
{
    [TestClass]
    public class PromotionsTests
    {
        private IWebDriver driver;
        private NotinoPromotionsPage promoPage;

        [TestInitialize]
        public void Before()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.notino.ro/");

            var menu = new LoggedOutMenuControl(driver);
            var loginPage = menu.NavigateToLoginPage();
            var homePage = loginPage.LoginApplication("constantin.beleca@yahoo.com", "Constantin1");
            promoPage = homePage.loggedInMenuControl.NavigateToPromotionsPage();
        }

        [TestMethod]
        public void Should_reach_perfume_promotions() 
        {
            var perfumePromo = promoPage.NavigateToPerfumePromotions();
            Assert.AreEqual(perfumePromo.LblPerfume.Text, "Promoții - Parfumuri");
        }

        [TestCleanup]
        public void After()
        {
            driver.Quit();
        }
    }
}
