using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace SeleniumTraining
{
    [TestClass]
    public class Autotests
    {
        IWebDriver driver;
        WebDriverWait wait;

        [TestInitialize]
        public void Init()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            driver = new ChromeDriver(options);
        }

        [TestMethod]
        public void Homework1()
        {
            driver.Navigate().GoToUrl("http://158.101.173.161/admin");

            if (driver.FindElements(By.Name("query")).Count == 0)
            {
                driver.FindElement(By.Name("username"), 1000).SendKeys("testadmin");
                driver.FindElement(By.Name("password"), 1000).SendKeys("testadmin" + Keys.Enter);
            }

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("box-apps-menu")));
            Thread.Sleep(1000);

            for (int i = 1; i <= driver.FindElements(By.ClassName("app")).Count; i++)
            {
                driver.FindElement(By.XPath($"//li[contains(@class, 'app')][{i}]")).Click();
                Assert.IsTrue(driver.FindElement(By.ClassName("panel-heading")).Displayed, "Panel-heading not found!");

                for (int j = 1; j <= driver.FindElements(By.ClassName("doc")).Count; j++)
                {
                    driver.FindElement(By.XPath($"//li[contains(@class, 'doc')][{j}]")).Click();
                    Assert.IsTrue(driver.FindElement(By.ClassName("panel-heading")).Displayed, "Panel-heading not found!");
                }
            }
        }

        [TestMethod]
        public void Homework2()
        {

        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}
