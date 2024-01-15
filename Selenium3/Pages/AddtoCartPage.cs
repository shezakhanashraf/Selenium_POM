using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Selenium3.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace Selenium3.Pages
{
    public class AddtoCartPage: Setup.SetupConfig
    {
        IWebDriver driver;

        // Add a constructor to receive the driver instance
        public void SetDriver(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Locators

        //Add to Cart Locators 
        public By productTitle = By.XPath("//span[text()='Products']");
        public By shoppingCart = By.Id("shopping_cart_container");
        public By checkout = By.Id("checkout");
        public By firstName = By.Id("first-name");
        public By lastName = By.Id("last-name");
        public By postalCode = By.Id("postal-code");
        public By continueBtn = By.Id("continue");
        public By finishBtn = By.Id("finish");
        public By errorMsg = By.XPath("//*[@id='checkout_info_container']/div/form/div[1]/div[4]/h3");
        public By removeBtn = By.Id("remove-sauce-labs-backpack");
        public By elementDisplay = By.XPath("//*[@id='header_container']/div[1]/div[2]/div");
        public IWebElement button;
        public IWebElement element;
        private IWebDriver driver1;

        #endregion

        #region Methods

        public void addProductToCart(string name)
        {
            driver.FindElement(By.Id("add-to-cart-sauce-labs-" + name + "")).Click();
            Console.WriteLine(name);
        }

        public void clickOnCart()
        {
            driver.FindElement(shoppingCart).Click();
        }

        public void clickOnCheckout()
        {
            driver.FindElement(checkout).Click();
        }

        public void addFirstName()
        {
            driver.FindElement(firstName).SendKeys(Core.TestConfiguration.Instance.FirstName);
        }

        public void addLastName()
        {
            driver.FindElement(lastName).SendKeys(Core.TestConfiguration.Instance.LastName);
        }
        public void addPostalCode()
        {
            driver.FindElement(postalCode).SendKeys(Core.TestConfiguration.Instance.PostalCode);
        }
        public void clickOnContinue()
        {
            driver.FindElement(continueBtn).Click();
        }
        public void clickOnFinish()
        {
            driver.FindElement(finishBtn).Click();
        }

        public void clickOnRemove()
        {
            driver.FindElement(removeBtn).Click();
        }

        //Assertions 
        public void getTextDisplayed(By locator, string actualMessage, string expectedMessage)
        {
            actualMessage = driver.FindElement(locator).Text;

            Assert.AreEqual(expectedMessage, actualMessage, "Actual message does not match the expected message.");
        }

        public void urlConfirmation(string expectedUrl)
        {
            Assert.AreEqual(expectedUrl, driver.Url, "URL does not match.");

        }
        public void checkButtonEnabled(By locator)
        {
            button = driver.FindElement(locator);
            bool isButtonEnabled = button.Enabled;

            Assert.IsTrue(isButtonEnabled, "Button is not enabled.");
        }
        public void checkElementVisibility(By locator)
        {
            IWebElement element = driver.FindElement(locator);
            Assert.IsTrue(element.Displayed, "Element is not displayed.");
        }

        public void checkElementNotVisible(By locator)
        {
            IWebElement element = driver.FindElement(locator);
            Assert.IsFalse(!element.Displayed, "Element is not displayed.");
        }

        #endregion 



    }
}
