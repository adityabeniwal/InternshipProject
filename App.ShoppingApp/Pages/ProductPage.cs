using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Common.Pages;
using OpenQA.Selenium;

namespace App.ShoppingApp.Pages
{
    public class ProductPage : CommonBasePage
    {
        public ProductPage(IWebDriver driver) : base(driver)
        {

        }

        public IWebElement AddtoCartButton => Driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));

        public IWebElement OpenCartButton => Driver.FindElement(By.Id("shopping_cart_container"));


        public void AddToCart()
        {
            AddtoCartButton.Click();

        }

        public CartPage OpenCartPage()
        {
            OpenCartButton.Click();
            return new CartPage(Driver);
        }
    }
}
