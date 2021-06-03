using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SIA12BaleaBelecaHolban.PageObjectsHelper
{
    public class NotinoMenPage
    {
        private IWebDriver driver;

        private By menTitle = By.CssSelector("div[class='category-component category-component--title']");
        public IWebElement LblMen => driver.FindElement(menTitle);

        public NotinoMenPage(IWebDriver browser)
        {
            driver = browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(menTitle));
        }

        public NotinoMenSection NavigateToMenSection()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(menTitle));
            LblMen.Click();
            return new NotinoMenSection(driver);
        }
    }
}
