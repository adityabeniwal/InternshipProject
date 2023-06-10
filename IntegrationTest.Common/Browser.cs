﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace IntegrationTest.Common
{
    public class Browser:IDisposable
    {
        public IWebDriver Driver { get; }
        public BrowserTypeEnum BrowserType { get; }

        public Browser(BrowserTypeEnum browser = BrowserTypeEnum.InternetExplorer)
        {
            BrowserType = browser;

            ConfigNLog.Logger.Info("Driver create start");

            Driver = BrowserFactory.CreateWebDriver(browser, Settings.RunWithGrid);

            ConfigNLog.Logger.Info("Driver create end");

            if (Settings.RunWithGrid)
            {
                ConfigNLog.Logger.Info("Get grid node name start");

                var machineName = GetGridMachine(Driver);

                //Console.WriteLine(">>> C GRID machine: " + machineName, ConsoleColor.Blue);   //Jenkins log will show this message. That is not necessary.
                Debug.WriteLine(">>> D GRID machine: " + machineName, ConsoleColor.Blue);
                Trace.WriteLine(">>> T GRID machine: " + machineName);

                ConfigNLog.Logger.Info("Get grid node name " + machineName + " end");
            }

        }



    }
}
