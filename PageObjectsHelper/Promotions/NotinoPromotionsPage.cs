using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SIA12BaleaBelecaHolban.PageObjectsHelper
{
    public class NotinoPromotionsPage
    {
        private IWebDriver driver;
        private By perfumePromo = By.CssSelector("img[alt='PROMOȚII LA PARFUMURI']");
        public IWebElement BtnPerfumePromo => driver.FindElement(perfumePromo);

        public NotinoPromotionsPage(IWebDriver browser) 
        {
            driver = browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(perfumePromo));
        }

        public NotinoPerfumePromotions NavigateToPerfumePromotions() 
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(perfumePromo));
            BtnPerfumePromo.Click();
            return new NotinoPerfumePromotions(driver);
        }
    }
}
