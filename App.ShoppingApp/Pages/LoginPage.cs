using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Common.Pages;
using WebDriver.Extensions;

namespace App.ShoppingApp.Pages
{
    public class LoginPage : CommonBasePage

    {
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public IWebElement UserNameElement => Driver.FindElement(By.Id("user-name"));
        public IWebElement PasswordElement => Driver.FindElement(By.Id("password"));
        public IWebElement LoginButtonElement => Driver.FindElement(By.Id("login-button"));

        public AllItemsPage  LoginUser(string username, string password)
        {
            UserNameElement.SendKeys(username);
            PasswordElement.SendKeys(password);
            LoginButtonElement.Click();

            return new AllItemsPage(Driver);
            
        }

        public bool GetLogoutConfirmation()
        {
            if (Driver.HasElement(By.Id("login-button")))
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
