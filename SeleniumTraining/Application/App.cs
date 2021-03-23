using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumTraining.Pages;

namespace SeleniumTraining.Application
{
    class App
    {
        IWebDriver driver;
        WebDriverWait wait;
        string baseUrl = "http://158.101.173.161";

        public HomePage homePage;
        public CartPage cartPage;
        ProductPage productPage;

        public App()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            driver = new ChromeDriver(options);
            Context context = new Context();
            context.SetDriver(driver);
            context.SetBaseUrl(baseUrl);

            homePage = new HomePage(context);
            cartPage = new CartPage(context);
            productPage = new ProductPage(context);
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseUrl);
        }

        public void OpenCartPage()
        {
            driver.FindElement(By.CssSelector("#cart")).Click();
            driver.FindElement(By.Id("box-checkout-cart"), 2000);
        }

        internal void Quit()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}
