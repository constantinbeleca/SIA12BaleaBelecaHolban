using System.Collections.Generic;
using OpenQA.Selenium;
using SIA12BaleaBelecaHolban.Utils;

namespace SIA12BaleaBelecaHolban.PageObjectsHelper
{
    public class NotinoBillingPage
    {
        private IWebDriver driver;

        public NotinoBillingPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By PhoneNo = By.Name("phone");
        public IWebElement TxtPhoneNo => driver.FindElement(PhoneNo);

        private By FirstName = By.Name("billingAddress.firstName");
        public IWebElement TxtFirstName => driver.FindElement(FirstName);

        private By LastName = By.Name("billingAddress.lastName");
        public IWebElement TxtLastName => driver.FindElement(LastName);

        private By Address1 = By.Name("billingAddress.street");
        public IWebElement TxtAddress1 => driver.FindElement(Address1);

        private By City = By.Name("billingAddress.city");
        public IWebElement TxtCity => driver.FindElement(City);

        private By StateList = By.CssSelector("[class ='sc-fyjqAk ctVwTX'] option");
        public IList<IWebElement> LstStates => driver.FindElements(StateList);

        private By ZipCode = By.Name("billingAddress.zipCode");
        public IWebElement TxtZipCode => driver.FindElement(ZipCode);

        private By CreateBillingInfo = By.CssSelector("button[class='sc-hHEiqL fmzFfT sc-dlMDgC fnjHxU sc-lmgQwP dQUHtJ']");
        public IWebElement BtnCreateBillingInfo => driver.FindElement(CreateBillingInfo);

        private By Username = By.CssSelector("div[class='username']");
        public IWebElement DivUsername => driver.FindElement(Username);

        private By Error = By.CssSelector("span[class='sc-fcmMJX bRzrLL']");
        public IWebElement LblPhoneError => driver.FindElement(Error);
        public IWebElement LblNameError => driver.FindElement(Error);
        public IWebElement LblCityError => driver.FindElement(Error);



        public void SaveBillingInfo(NewBillingInfoBO newBillingInfoBO)
        {
            WaitHelpers.WaitElementToBeVisible(driver, CreateBillingInfo);

            ClearAllData();

            TxtPhoneNo.SendKeys(newBillingInfoBO.PhoneNo);
            TxtFirstName.SendKeys(newBillingInfoBO.FirstName);
            TxtLastName.SendKeys(newBillingInfoBO.LastName);
            TxtAddress1.SendKeys(newBillingInfoBO.Address1);
            TxtCity.SendKeys(newBillingInfoBO.City);
            TxtZipCode.SendKeys(newBillingInfoBO.ZipCode);
            SelectStateFromList();

            BtnCreateBillingInfo.Click();
        }

        public void ClearAllData() 
        {
            ClearElement(TxtPhoneNo);
            ClearElement(TxtFirstName);
            ClearElement(TxtLastName);
            ClearElement(TxtAddress1);
            ClearElement(TxtCity);
            ClearElement(TxtZipCode);
        }

        public void SelectStateFromList()
        {
            foreach (var state in LstStates)
            {
                if (state.Text.Equals("Iasi"))
                {
                    state.Click();
                    break;
                }
            }
        }

        private void ClearElement(IWebElement element) 
        {
            var value = element.GetAttribute("value");
            var valLen = value.ToString().Length;
            while (valLen > 0) 
            {
                element.SendKeys(Keys.Backspace);
                valLen--;
            }
        }
    }
}
