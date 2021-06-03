using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SIA12BaleaBelecaHolban.PageObjectsHelper;

namespace SIA12BaleaBelecaHolban
{
    [TestClass]
    public class BillingTests
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
            var homePage = loginPage.LoginApplication("constantin.beleca@yahoo.com", "Constantin1");
        }

        [TestCleanup]
        public void After()
        {
            driver.Quit();
        }

        [TestMethod]
        public void Should_add_billing_info_successfully() 
        {
            var billingPage = loginPage.NavigateToBillingPage();
            var newBillingInfo = new NewBillingInfoBO()
            {
                FirstName = "NEW FIRST NAME"
            };

            billingPage.SaveBillingInfo(newBillingInfo);
            var successfullyAdded = new SuccessfullyAddedBillingInfo(driver);
            Assert.AreEqual(newBillingInfo.FirstName, successfullyAdded.LblUsername.Text);
        }

        [TestMethod]
        public void Should_change_address_successfully() 
        {
            var billingPage = loginPage.NavigateToBillingPage();
            var newBillingInfo = new NewBillingInfoBO()
            {
                Address1 = "PIATA UNIRII"
            };

            billingPage.SaveBillingInfo(newBillingInfo);
            var successfullyAdded = new SuccessfullyAddedBillingInfo(driver);
            Assert.AreEqual(newBillingInfo.Address1, successfullyAdded.LblAddress1.Text);
        }

        [TestMethod]
        public void Should_change_city_successfully()
        {
            var billingPage = loginPage.NavigateToBillingPage();
            var newBillingInfo = new NewBillingInfoBO()
            {
                City = "IASI"
            };

            billingPage.SaveBillingInfo(newBillingInfo);
            var successfullyAdded = new SuccessfullyAddedBillingInfo(driver);
            Assert.AreEqual(newBillingInfo.City, successfullyAdded.LblCity.Text);
        }

        [TestMethod]
        public void Should_change_last_name_successfully()
        {
            var billingPage = loginPage.NavigateToBillingPage();
            var newBillingInfo = new NewBillingInfoBO()
            {
                LastName = "NEW LAST NAME"
            };

            billingPage.SaveBillingInfo(newBillingInfo);
            var successfullyAdded = new SuccessfullyAddedBillingInfo(driver);
            Assert.AreEqual(newBillingInfo.LastName, successfullyAdded.LblLastName.Text);
        }

        [TestMethod]
        public void Should_change_zipcode_successfully()
        {
            var billingPage = loginPage.NavigateToBillingPage();
            var newBillingInfo = new NewBillingInfoBO()
            {
                ZipCode = "700280"
            };

            billingPage.SaveBillingInfo(newBillingInfo);
            var successfullyAdded = new SuccessfullyAddedBillingInfo(driver);
            Assert.AreEqual(newBillingInfo.ZipCode, successfullyAdded.LblZipcode.Text);
        }
    }
}
