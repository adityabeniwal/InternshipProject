using NLog.Config;
using NLog.LayoutRenderers;
using NLog;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Common.Nlog
{
    [LayoutRenderer("elapsedtime")]
    [ThreadAgnostic]
    public class ElapsedTimeLayoutRenderer : LayoutRenderer
    {
        Stopwatch sw;

        public ElapsedTimeLayoutRenderer()
        {
            this.sw = Stopwatch.StartNew();
        }

        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            var el = this.sw.Elapsed;
            builder.Append(Math.Round(el.TotalSeconds).ToString().PadLeft(6) + "s");
            this.sw.Restart();
        }
    }

    //TestExecutionContext.CurrentContext.CurrentTest.FullName

    [LayoutRenderer("testname")]
    [ThreadAgnostic]
    public class TestNameLayoutRenderer : LayoutRenderer
    {

        public TestNameLayoutRenderer()
        {
        }

        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            String name = "";
            try
            {
                name = TestExecutionContext.CurrentContext.CurrentTest.FullName;
                name = name.Replace(".IntegrationTests", "");
            }
            catch
            {
                name = "Not possible to get test name :-(";
            };

            builder.Append(name);
        }
    }
}
