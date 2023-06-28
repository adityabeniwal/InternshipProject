using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationTest.Common;
using NUnit.Framework.Internal;
using App.ShoppingApp.Navigation;
using App.ShoppingApp.Pages;
using IntegrationTest.Common.Nlog;

namespace ShoppingApp.IntegrationTest
{
    [TestFixture]
    public class LoginAndLogoutTest:SwagLabsTestBase

    {
        private AppNavigation navigation;
        public TestUser testUser = new TestUser();
        [SetUp]
        public void TestSetup()
        {
            navigation = new AppNavigation(Driver);
        }

        [Test, Description("Login into website using given credentials")]

        public void LoginCheck()
        {
            var loginPage = new LoginPage(Driver);
            var allItemsPage=loginPage.LoginUser(testUser.Username, testUser.Password);
            Thread.Sleep(5000);
            Assert.IsTrue(allItemsPage.GetLoginConfirmation());

        }

        [Test, Description("Login into website using given credentials and then Logout")]

        public void LoginAndLogoutCheck()
        {
            var loginPage = new LoginPage(Driver);
            var allItemsPage = loginPage.LoginUser(testUser.Username, testUser.Password);
            Thread.Sleep(5000);
            Assert.IsTrue(allItemsPage.GetLoginConfirmation());

            loginPage=allItemsPage.LogoutFromApp();
            Thread.Sleep(5000);
            Assert.IsTrue(loginPage.GetLogoutConfirmation());

        }

    }
}
