using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SIA12BaleaBelecaHolban.PageObjectsHelper
{
    public class NotinoLoginPage
    {
        public IWebDriver driver;

        public NotinoLoginPage(IWebDriver browser)
        {
            driver = browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(SignIn));
        }

        private By Email = By.Id("login-name");
        public IWebElement TxtEmail => driver.FindElement(Email);

        private By Password = By.Id("login-pwd");
        public IWebElement TxtPassword => driver.FindElement(Password);

        private By SignIn = By.CssSelector("button[type='submit']");
        public IWebElement BtnSignIn => driver.FindElement(SignIn);

        public IWebElement LblLoginFailed => driver.FindElement(By.CssSelector("span[class='message error-message']"));

        private By BillingInfo = By.LinkText("Date de contact");
        public IWebElement BtnBillingInfo => driver.FindElement(BillingInfo);

        public NotinoHomePage LoginApplication(string email, string password)
        {
            TxtEmail.SendKeys(email);
            TxtPassword.SendKeys(password);
            BtnSignIn.Click();
            return new NotinoHomePage(driver);
        }

        public NotinoBillingPage NavigateToBillingPage() 
        {
            BtnBillingInfo.Click();
            return new NotinoBillingPage(driver);
        }
    }
}
