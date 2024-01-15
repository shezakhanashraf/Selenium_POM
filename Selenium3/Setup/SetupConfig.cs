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
using WebDriverManager.DriverConfigs.Impl;
using Selenium3.Core;

namespace Selenium3.Setup
{
    [TestClass]
    public class SetupConfig
    {
        public static IWebDriver driver;
        LoginPage loginPage;
        TestData.TestData data = new TestData.TestData();

        public void Setup(string browsername, string url)
        {
            driver = Browser(browsername);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            // Instantiate LoginPage with the driver instance
            loginPage = new LoginPage(driver);
            loginPage.sendUserName();
            loginPage.sendPassword();
            loginPage.clickOnLoginBtn();
        }

        static IWebDriver Browser(string browserName)
        {
            if (browserName.ToLower() == "chrome")
            {
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                return new ChromeDriver();
            }
            if (browserName.ToLower() == "firefox")
            {
                return new FirefoxDriver();
            }
            if (browserName.ToLower() == "edge")
            {
                return new EdgeDriver();
            }
            else
            {
                return new ChromeDriver();
            }
        }

        [TestCleanup]
        public void QuitDriver()
        {
            driver.Quit();
        }
    }
}
