using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace App.Common.Pages
{
    public class CommonBasePage
    {
        protected CommonBasePage(IWebDriver driver)
        {
            Driver = driver;
            
        }
        public CommonBasePage()
        {
        }
        protected IWebDriver Driver { get; }
    }
}
