using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationTest.Common;

namespace ShoppingApp.IntegrationTest
{
    public class SwagLabsTestBase:ShoppingAppIntegrationTestBase

    {
        protected override void SetEnvironment()
        {

        }

        protected override void InitBrowser()
        {
            _browser?.Dispose();
            _browser = new Browser(BrowserTypeEnum.Chrome);
            InitBrowser(new TestUser());
        }
    }
}
