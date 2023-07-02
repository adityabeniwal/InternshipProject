using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Common.Pages;
using OpenQA.Selenium;
using WebDriver.Extensions;

namespace App.ShoppingApp.Pages
{
    public class CompletePage:CommonBasePage
    {
        public CompletePage(IWebDriver driver) : base(driver)
        {

        }

        public IWebElement CompleteCheckoutElement => Driver.FindElement(By.XPath("//*[@id='checkout_complete_container']/h2"));

        public bool GetCheckoutCompleteConfirmation()
        {
            if (Driver.HasElement(CompleteCheckoutElement))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
