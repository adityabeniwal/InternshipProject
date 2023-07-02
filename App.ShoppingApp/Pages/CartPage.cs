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
    public class CartPage : CommonBasePage
    {
        public CartPage(IWebDriver driver) : base(driver)
        {

        }

        public IWebElement RemoveFromCartButton => Driver.FindElement(By.Id("remove-sauce-labs-backpack"));

        public IWebElement CheckoutButton => Driver.FindElement(By.Id("checkout"));


        public bool GetItemInCartConfirmation()
        {
            if (Driver.HasElement(By.LinkText("Sauce Labs Backpack")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveFromCart()
        {
            RemoveFromCartButton.Click();
        }

        public CheckoutPage CheckoutFromCart()
        {
            CheckoutButton.Click();
            return new CheckoutPage(Driver);

        }
    }
}
