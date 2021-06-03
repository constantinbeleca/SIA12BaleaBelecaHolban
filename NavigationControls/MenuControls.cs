using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SIA12BaleaBelecaHolban.PageObjectsHelper;
using SIA12BaleaBelecaHolban.Utils;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SIA12BaleaBelecaHolban.NavigationControls
{
    public class MenuControls
    {
        public IWebDriver driver;

        public MenuControls(IWebDriver browser)
        {
            driver = browser;
        }

        private By home = By.CssSelector("");
        public IWebElement BtnHome => driver.FindElement(home);
    }

    public class LoggedOutMenuControl : MenuControls
    {
        public LoggedOutMenuControl(IWebDriver browser) : base(browser) 
        { }

        private By LogIn = By.ClassName("_1W8FHoGkAK1-vShN-OLaxj");
        public IWebElement BtnLogIn => driver.FindElement(LogIn);

        public NotinoLoginPage NavigateToLoginPage() 
        {
            WaitHelpers.WaitElementToBeVisible(driver, LogIn);
            BtnLogIn.Click();
            return new NotinoLoginPage(driver);
        }
    }

    public class LoggedInMenuControl : MenuControls 
    {
        public LoggedInMenuControl(IWebDriver browser) : base(browser) 
        { 
        }

        private By Email = By.CssSelector("div[class='email m-hide']");
        public IWebElement LblEmail => driver.FindElement(Email);

        private By Men = By.CssSelector("div[data-cypress='mainMenu-Bărbați']");
        public IWebElement LblMen => driver.FindElement(Men);

        private By Promotions = By.CssSelector("div[data-cypress='mainMenu-PROMOȚII']");
        public IWebElement BtnPromotions => driver.FindElement(Promotions);

        public NotinoPromotionsPage NavigateToPromotionsPage()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(Email));
            BtnPromotions.Click();
            return new NotinoPromotionsPage(driver);
        }

        public NotinoMenPage NavigateToMenPage() 
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(Men));
            LblMen.Click();
            return new NotinoMenPage(driver);
        }

    }
}
