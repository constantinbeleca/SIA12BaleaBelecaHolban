using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SIA12BaleaBelecaHolban.PageObjectsHelper
{
    public class NotinoMenSection
    {
        public IWebDriver driver;
        private By menTitle = By.CssSelector("div[class='category-component category-component--title']");
        public IWebElement LblMen => driver.FindElement(menTitle);

        public NotinoMenSection(IWebDriver browser)
        {
            driver = browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(menTitle));
        }
    }
}
