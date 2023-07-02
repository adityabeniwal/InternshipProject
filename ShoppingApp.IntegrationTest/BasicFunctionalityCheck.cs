using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.ShoppingApp.Navigation;
using App.ShoppingApp.Pages;
using IntegrationTest.Common;
using NUnit.Framework;

namespace ShoppingApp.IntegrationTest
{
    [TestFixture]
    public class BasicFunctionalityCheck:SwagLabsTestBase
    {
        private AppNavigation navigation;
        public TestUser testUser = new TestUser();
        [SetUp]
        public void TestSetup()
        {
            navigation = new AppNavigation(Driver);
        }

        [Test, Description("Add product to cart from All items page and complete the workflow")]

        public void CompleteWorkflowFrommAllItemsPage()
        {
            var loginPage = new LoginPage(Driver);
            var allItemsPage = loginPage.LoginUser(testUser.Username, testUser.Password);
            Thread.Sleep(5000);
            Assert.IsTrue(allItemsPage.GetLoginConfirmation());
            allItemsPage.AddToCart();
            Thread.Sleep(5000);
            var cartPage = allItemsPage.OpenCartPage();
            Thread.Sleep(5000);
            Assert.IsTrue(cartPage.GetItemInCartConfirmation());
            var checkoutPage = cartPage.CheckoutFromCart();
            checkoutPage.EnterInformationOnCheckout(testUser.FirstName,testUser.LastName,testUser.ZipCode);
            var overViewPage=checkoutPage.PerfromCheckout();
            var completePage = overViewPage.PerformFinish();
            Assert.IsTrue(completePage.GetCheckoutCompleteConfirmation());
        }

    }
}
