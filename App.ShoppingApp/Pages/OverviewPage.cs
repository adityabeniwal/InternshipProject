using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Common.Pages;
using OpenQA.Selenium;

namespace App.ShoppingApp.Pages
{
    public class OverviewPage : CommonBasePage
    {
        public OverviewPage(IWebDriver driver) : base(driver)
        {

        }

        public IWebElement FinishButtonElement => Driver.FindElement(By.Id("finish"));

        public CompletePage PerformFinish()
        {
            FinishButtonElement.Click();
            Thread.Sleep(2000);
            return new CompletePage(Driver);
        }

    }
}
