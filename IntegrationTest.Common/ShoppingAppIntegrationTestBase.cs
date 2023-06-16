using App.Common.Helpers;
using IntegrationTest.Common.Nlog;
using NUnit.Framework.Internal;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Common
{
    public class ShoppingAppIntegrationTestBase:TearDownTestBase
    {
        private bool ApplyConfig = true;


        protected void InitBrowser(TestUser user, string url = null)
        {
            if (_browser == null)
                _browser = new Browser(BrowserTypeEnum.Chrome);

            ConfigNLog.Logger.Info("Url open start");

            _browser.OpenApp(url ?? "https://www.saucedemo.com/", user);

            ConfigNLog.Logger.Info("Url open end");

            CloseOtherTabs();
        }

        private void CloseOtherTabs()
        {
            var windowsToClose = Driver.WindowHandles.ToList().Where(x => x != Driver.CurrentWindowHandle).ToList();

            foreach (var oneWin in windowsToClose)
                Driver.SwitchTo().Window(oneWin).Close();

            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
        }

        //Restart browser with different user
        protected void RestartBrowser(TestUser user, string url = null)
        {
            _browser?.Dispose();

            _browser = new Browser(BrowserTypeEnum.Chrome);

            InitBrowser(user, url);
        }


        protected static string ChangeAppInUrl(string oldUrl, string newAppId, string pageId = null)
        {
            return oldUrl.Substring(0, oldUrl.IndexOf("f?p=") + 4) + newAppId + (pageId != null ? ":" + pageId : "");
        }

        public void SetEnvironment(List<string> configurationNames)
        {
            ConfigNLog.Logger.Info("SetEnvironment start");

            if (configurationNames.Any())
            {
                //using (var configDb = new UserConf())
                //{
                //    foreach (var configurationName in configurationNames)
                //        configDb.PrepareData(configurationName);
                //}
            }


            ConfigNLog.Logger.Info("SetEnvironment end");
        }

        protected virtual void InitBrowser()
        {

            InitBrowser( new TestUser() );
        }

        protected virtual void SetEnvironment()
        {
            SetEnvironment(new List<string>());
        }

        [SetUp]
        public void SetUp()
        {
            try
            {
                ConfigNLog.Logger.Info("SetUp start");
                

                var w = new Stopwatch();
                w.Start();


                InitBrowser();


                //clear previous screenshots
                TakeScreenshot.ScreenshotsTaken.Clear();
            }
            catch (Exception ex)
            {
                ConfigNLog.Logger.Error(ex, "SetUp exception ");

#if DEBUG
                throw ex;
#endif
            }

            ConfigNLog.Logger.Info("SetUp end");
            ConfigNLog.Logger.Info("Test execution start");
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ConfigNLog.Defaults();

            ConfigNLog.Logger.Info("OneTimeSetUp start");

            if (ApplyConfig)
                SetEnvironment();

            // _browser = new Browser(BrowserTypeEnum.Chrome);

            ConfigNLog.Logger.Info("OneTimeSetUp end");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ConfigNLog.Logger.Info("OneTimeTeardon start");

            _browser?.Dispose();

            Process[] procsChromedriver = Process.GetProcessesByName("chromedriver");
            if (procsChromedriver.Length > 0)
                foreach (var process in procsChromedriver)
                    process.Close();
            Process[] procsChrome = Process.GetProcessesByName("chrome");
            foreach (var process in procsChrome)
                process.Close();
            ConfigNLog.Logger.Info("OneTimeTeardown end");
        }
    }
}
