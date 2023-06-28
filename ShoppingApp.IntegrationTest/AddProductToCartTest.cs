using IntegrationTest.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.ShoppingApp.Navigation;
using App.ShoppingApp.Pages;

namespace ShoppingApp.IntegrationTest
{
    [TestFixture]
    public class AddProductToCartTest:SwagLabsTestBase
    {
        private AppNavigation navigation;
        public TestUser testUser = new TestUser();
        [SetUp]
        public void TestSetup()
        {
            navigation = new AppNavigation(Driver);
        }

        [Test, Description("Add product to cart from All items page and remove form cart page")]

        public void AddAndRemoveProductFromCart()
        {
            var loginPage = new LoginPage(Driver);
            var allItemsPage = loginPage.LoginUser(testUser.Username, testUser.Password);
            Thread.Sleep(5000);
            Assert.IsTrue(allItemsPage.GetLoginConfirmation());
            allItemsPage.AddToCart();
            Thread.Sleep(5000);
            var cartPage=allItemsPage.OpenCartPage();
            Thread.Sleep(5000);
            Assert.IsTrue(cartPage.GetItemInCartConfirmation());
            cartPage.RemoveFromCart();
            Thread.Sleep(5000);
            Assert.IsFalse(cartPage.GetItemInCartConfirmation());
        }

        [Test, Description("Add product to cart from Product Page and remove form cart page")]


        public void AddAndRemoveFromProductPage()
        {
            var loginPage = new LoginPage(Driver);
            var allItemsPage = loginPage.LoginUser(testUser.Username, testUser.Password);
            Thread.Sleep(5000);
            Assert.IsTrue(allItemsPage.GetLoginConfirmation());
            var productPage=allItemsPage.OpenProductPage();
            productPage.AddToCart();
            var cartPage = productPage.OpenCartPage();
            Assert.IsTrue(cartPage.GetItemInCartConfirmation());
            cartPage.RemoveFromCart();
            Assert.IsFalse(cartPage.GetItemInCartConfirmation());

        }
    }
}
