using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium3.Core;

namespace Selenium3.Pages
{
    public class LoginPage:Setup.SetupConfig
    {
        IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Locators

        //Login Locators 
        public By title = By.ClassName("login_logo");
        public By username = By.Id("user-name");
        public By password = By.Id("password");
        public By loginBtn = By.Id("login-button");
        public By errorMsg = By.XPath("//h3[@data-test='error']");

        #endregion

        #region Methods

        public void sendUserName()
        {
           driver.FindElement(username).SendKeys(TestConfiguration.Instance.UserName);
        }

        public void sendPassword()
        {
            driver.FindElement(password).SendKeys(TestConfiguration.Instance.Password);
        }

        public void clickOnLoginBtn()
        {
            driver.FindElement(loginBtn).Click();
        }

        #endregion

    }
}
