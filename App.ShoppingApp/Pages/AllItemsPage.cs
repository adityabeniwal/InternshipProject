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
    public class AllItemsPage : CommonBasePage
    {
        public AllItemsPage(IWebDriver driver) : base(driver)
        {

        }

        public IWebElement LeftMenuButton => Driver.FindElement(By.Id("react-burger-menu-btn"));

        public IWebElement LogoutButton => Driver.FindElement(By.Id("logout_sidebar_link"));

        public IWebElement AddToCartButton => Driver.FindElement(By.XPath("//*[@id='inventory_container']/div/div/div/div/div[2]/div[2]/button"));

        public IWebElement OpenCartButton => Driver.FindElement(By.Id("shopping_cart_container"));

        public IWebElement ProductButton => Driver.FindElement(By.Id("item_4_title_link"));


        public bool GetLoginConfirmation()
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

        public void OpenLeftMenu()
        {
            LeftMenuButton.Click();
        }

        public LoginPage LogoutFromApp()
        {
            OpenLeftMenu();
            Thread.Sleep(5000);
            LogoutButton.Click();
            return new LoginPage(Driver);
        }

        public void AddToCart()
        {
            AddToCartButton.Click();

        }

        public CartPage OpenCartPage()
        {
            OpenCartButton.Click();

            return new CartPage(Driver);
        }

        public ProductPage OpenProductPage()
        {
            ProductButton.Click();

            return new ProductPage(Driver);
        }
    }
}
