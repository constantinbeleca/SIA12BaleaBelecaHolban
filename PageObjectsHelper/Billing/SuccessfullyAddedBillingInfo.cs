using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

using System;

namespace SIA12BaleaBelecaHolban.PageObjectsHelper
{
    class SuccessfullyAddedBillingInfo
    {
        private IWebDriver driver;

        public SuccessfullyAddedBillingInfo(IWebDriver browser)
        {
            driver = browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(Username));
            wait.Until(ExpectedConditions.ElementIsVisible(LastName));
            wait.Until(ExpectedConditions.ElementIsVisible(Address1));
            wait.Until(ExpectedConditions.ElementIsVisible(City));
            wait.Until(ExpectedConditions.ElementIsVisible(Zipcode));
        }

        private By Username = By.CssSelector("div[class='username']");
        public IWebElement LblUsername => driver.FindElement(Username);

        private By LastName = By.Name("billingAddress.lastName");
        public IWebElement LblLastName => driver.FindElement(LastName);

        private By Address1 = By.Name("billingAddress.street");
        public IWebElement LblAddress1 => driver.FindElement(Address1);

        private By City = By.Name("billingAddress.city");
        public IWebElement LblCity => driver.FindElement(City);

        private By Zipcode = By.Name("billingAddress.zipCode");
        public IWebElement LblZipcode => driver.FindElement(Zipcode);
    }
}
