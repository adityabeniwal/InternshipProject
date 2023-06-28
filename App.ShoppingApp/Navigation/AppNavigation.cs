using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ShoppingApp.Navigation
{
    public class AppNavigation : Common.Navigation.AppNavigation
    {
        private readonly IWebDriver _driver;

        public AppNavigation(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }
    }
}
