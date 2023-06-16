
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using App.Common.Helpers;
using IntegrationTest.Common.Nlog;

namespace IntegrationTest.Common
{
    public class TearDownTestBase
    {
        protected bool AlreadyScreenshot = false;
        protected Browser _browser { get; set; }
        public IWebDriver Driver => _browser.Driver;

        public void SetBrowser(Browser browser)
        {
            _browser = browser;
        }

        public void ResetBrowser(BrowserTypeEnum browser)
        {
            _browser?.Dispose();
            _browser = new Browser(browser);
        }


        [SetUp]
        public virtual void InitializeFixture()
        {
        }

        protected void TearDown(IWebDriver driver = null)
        {
            var driverActual = driver ?? Driver;
            ConfigNLog.Logger.Info("Test execution end " + TestExecutionContext.CurrentContext.CurrentResult.ResultState.ToString());
            ConfigNLog.Logger.Info("TearDown start");


            try
            {
                driverActual.SwitchTo().DefaultContent();
            }
            catch (WebDriverException)
            {
                var browserType = _browser.BrowserType;
                _browser.Dispose();
            }

            ConfigNLog.Logger.Info("Teardown end");
        }

        [TearDown]
        public void TestTearDown()
        {
            TearDown();

        }

        protected void TakeScreenshots(ref string errMsgAdditional, IWebDriver driver = null)
        {
            var driverActual = driver ?? Driver;

            if (AlreadyScreenshot) return;

           

            Screenshot screenshot = null;

            try
            {
                var screenshotDriver = (ITakesScreenshot)driverActual;
                screenshot = screenshotDriver?.GetScreenshot();
            }
            catch
            {
            }

            if (screenshot != null)
            {
                //var currentTest = TestExecutionContext.CurrentContext.Test;

                var sceenFirst = new ScreenshotAndDescription();

                sceenFirst.ScreenshotImage = Image.FromStream(new MemoryStream(screenshot.AsByteArray));
                sceenFirst.Description = "Primary Browser Window";

                TakeScreenshot.ScreenshotsTaken.Add(sceenFirst);
            }
        }


    }
}
