using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Common
{
    internal class BrowserFactory
    {
        private const string SeleniumHubUrl = "url of selenium hub";
        internal static IWebDriver CreateWebDriver(BrowserTypeEnum browser = BrowserTypeEnum.Chrome,
           bool startInGrid = false)
        {
            var internetExplorerOptions = new InternetExplorerOptions
            {
                EnableNativeEvents = false
                //FileUploadDialogTimeout = IeFileUploadDialogTimeout
                // RequireWindowFocus = true,
            };

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--test-type");
            chromeOptions.AddArgument("--incognito");
            chromeOptions.AddArgument("--start-maximized");
            chromeOptions.AddArgument("--allow-no-sandbox-job");
            chromeOptions.AddArgument("--allow-no-sandbox-job");
            chromeOptions.AddArguments("--disable-backgrounding-occluded-windows");
            chromeOptions.AddArguments("--disable-background-timer-throttling");
            chromeOptions.AddArguments("--disable-renderer-backgrounding");
            //chromeOptions.AddArguments("--headless");

            var driverBasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "selenium");

            switch (browser)
            {
                case BrowserTypeEnum.Chrome:
                case BrowserTypeEnum.ChromeWithIETab:
                    return new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, chromeOptions, TimeSpan.FromSeconds(180));
                case BrowserTypeEnum.Firefox:
                    //var firefoxDriverService = FirefoxDriverService.CreateDefaultService(driverBasePath);
                    var firefoxDriverService = FirefoxDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory);
                    //firefoxDriverService.FirefoxBinaryPath = firefox64Path;
                    //firefoxDriverService.ConnectToRunningBrowser = false;

                    //var firefoxOptions = new FirefoxOptions();
                    //capabilityFirefox.AddArgument("-private");
                    //capabilityFirefox.SetPreference("browser.privatebrowsing.autostart", true);
                    //var drv = new FirefoxDriver(firefoxDriverService, capabilityFirefox, TimeSpan.FromSeconds(180));//return new FirefoxDriver(capabilityFirefox);
                    return null;
            }

            return null;
        }
    }
}
