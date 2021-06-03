using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SIA12BaleaBelecaHolban.PageObjectsHelper
{
    public class NotinoPerfumePromotions
    {
        public IWebDriver driver;
        private By PerfumeTitle = By.CssSelector("h1[class='component-title']");
        public IWebElement LblPerfume => driver.FindElement(PerfumeTitle);

        public NotinoPerfumePromotions(IWebDriver browser)
        {
            driver = browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(PerfumeTitle));
        }
    }
}
