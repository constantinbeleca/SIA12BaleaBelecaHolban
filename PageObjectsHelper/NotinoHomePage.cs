using OpenQA.Selenium;
using SIA12BaleaBelecaHolban.NavigationControls;

namespace SIA12BaleaBelecaHolban.PageObjectsHelper
{
    public class NotinoHomePage
    {
        private IWebDriver driver;

        public NotinoHomePage(IWebDriver browser)
        {
            driver = browser;
        }

        public LoggedInMenuControl loggedInMenuControl => new LoggedInMenuControl(driver);
    }
}
