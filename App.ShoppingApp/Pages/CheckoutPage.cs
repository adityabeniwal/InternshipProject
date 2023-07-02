using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Common.Pages;
using OpenQA.Selenium;

namespace App.ShoppingApp.Pages
{
    public class CheckoutPage : CommonBasePage
    {
        public CheckoutPage(IWebDriver driver) : base(driver)
        {

        }

        public IWebElement FirstNameElement => Driver.FindElement(By.Id("first-name"));
        public IWebElement LastNameElement => Driver.FindElement(By.Id("last-name"));
        public IWebElement ZipcodeElement => Driver.FindElement(By.Id("postal-code"));
        public IWebElement ContinueButtonElement => Driver.FindElement(By.Id("continue"));

        public void EnterInformationOnCheckout(string firstName, string lastName, string zipCode)
        {
            FirstNameElement.SendKeys(firstName);
            Thread.Sleep(1000);
            LastNameElement.SendKeys(lastName);
            Thread.Sleep(1000);
            ZipcodeElement.SendKeys(zipCode);
            Thread.Sleep(2000);
        }

        public OverviewPage PerfromCheckout()
        {
            ContinueButtonElement.Click();
            Thread.Sleep(2000);
            return new OverviewPage(Driver);
        }


    }
}
