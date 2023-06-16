using OpenQA.Selenium.DevTools;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog.Config;
using NLog.Layouts;
using NLog;

namespace IntegrationTest.Common.Nlog
{
    public static class ConfigNLog
    {
        public static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();


        public static void Defaults()
        {

            ConfigurationItemFactory.Default.LayoutRenderers
                .RegisterDefinition("elapsedtime", typeof(ElapsedTimeLayoutRenderer));
            ConfigurationItemFactory.Default.LayoutRenderers
                .RegisterDefinition("testname", typeof(TestNameLayoutRenderer));

            var config = new NLog.Config.LoggingConfiguration();

            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") { };
            logfile.FileName = "C:\\temp\\SeleniumLog.txt";
            logfile.Layout = Layout.FromString("${elapsedtime}|${longdate}|${level:uppercase=true}|${testname}|${message} ${exception:format=ToString,Properties,Data}");
            logfile.MaxArchiveDays = 30;

            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");
            logconsole.Layout = Layout.FromString("${elapsedtime}|${longdate}|${level:uppercase=true}|${testname}|${message} ${exception:format=ToString,Properties,Data}");

            // Rules for mapping loggers to targets            
            config.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal, logconsole);
            config.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal, logfile);


            // Apply config           
            NLog.LogManager.Configuration = config;


            Logger.Info("Loger is loading ...");
            Logger.Info("Loger is loading finished");
        }
    }
}
