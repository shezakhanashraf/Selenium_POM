using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using Selenium3.Pages;
using Selenium3.Setup;
using WebDriverManager.DriverConfigs.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Selenium3.Tests
{
    [TestClass]
    public class AddtoCart: SetupConfig
    {
        TestData.TestData data = new TestData.TestData();
        AddtoCartPage cartPage;

        [TestInitialize]
        public void Setup()
        {
            Setup(data.browsername, data.url);
            cartPage = new AddtoCartPage();
            cartPage.SetDriver(driver);

            Thread.Sleep(6000);
        }

        //Positive Cases

        [TestMethod]
        [DataRow("backpack")]
        public void addToCartProcess(string name)
        {
            cartPage.urlConfirmation(data.actualurl);
            cartPage.getTextDisplayed(cartPage.productTitle, "Products", "Products");
            cartPage.addProductToCart(name);
            cartPage.checkButtonEnabled(cartPage.shoppingCart);
            cartPage.clickOnCart();
            cartPage.clickOnCheckout();
            cartPage.addFirstName();
            cartPage.addLastName();
            cartPage.addPostalCode();
            cartPage.checkElementVisibility(cartPage.firstName);
            cartPage.clickOnContinue();
            cartPage.checkElementNotVisible(cartPage.finishBtn);
            cartPage.clickOnFinish();
        }

        [TestMethod]
        public void addMultipleProductstToCart()
        {
            cartPage.urlConfirmation(data.actualurl);
            cartPage.getTextDisplayed(cartPage.productTitle, "Products", "Products");
            cartPage.addProductToCart(data.productName);
            cartPage.addProductToCart(data.bikeLight);
            cartPage.addProductToCart(data.boltShirt);
            cartPage.addProductToCart(data.fleeceJacket);
            cartPage.checkButtonEnabled(cartPage.shoppingCart);
            cartPage.clickOnCart();
            cartPage.clickOnCheckout();
            cartPage.addFirstName();
            cartPage.addLastName();
            cartPage.addPostalCode();
            cartPage.clickOnContinue();
            cartPage.clickOnFinish();
        }


        //Negative Cases

        [TestMethod]
        public void emptyCartCheckout()
        {
            cartPage.urlConfirmation(data.actualurl);
            cartPage.getTextDisplayed(cartPage.productTitle, "Products", "Products");
            cartPage.checkButtonEnabled(cartPage.shoppingCart);
            cartPage.clickOnCart();
            cartPage.clickOnCheckout();
            cartPage.clickOnContinue();
            cartPage.getTextDisplayed(cartPage.errorMsg, "Error: First Name is required", "Error: First Name is required");
        }

        [TestMethod]
        public void oneProductCartCheckout()
        {
            cartPage.urlConfirmation(data.actualurl);
            cartPage.getTextDisplayed(cartPage.productTitle, "Products", "Products");
            cartPage.addProductToCart(data.productName);
            cartPage.checkButtonEnabled(cartPage.shoppingCart);
            cartPage.clickOnCart();
            cartPage.clickOnRemove();
            cartPage.clickOnCheckout();
            cartPage.clickOnContinue();
            cartPage.getTextDisplayed(cartPage.errorMsg, "Error: First Name is required", "Error: First Name is required");
        }

        [TestMethod]
        public void onlyFirstNameAdded()
        {
            cartPage.urlConfirmation(data.actualurl);
            cartPage.getTextDisplayed(cartPage.productTitle, "Products", "Products");
            cartPage.addProductToCart(data.productName);
            cartPage.checkButtonEnabled(cartPage.shoppingCart);
            cartPage.clickOnCart();
            cartPage.clickOnCheckout();
            cartPage.addFirstName();
            cartPage.clickOnContinue();
            cartPage.getTextDisplayed(cartPage.errorMsg,"Error: Last Name is required", "Error: Last Name is required");
        }
    }
}
