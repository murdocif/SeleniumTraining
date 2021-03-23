using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;
using SeleniumTraining.Application;

namespace SeleniumTraining
{
    [TestClass]
    public class Autotests
    {
        //IWebDriver driver;
        //WebDriverWait wait;

        [TestInitialize]
        public void Init()
        {
            //ChromeOptions options = new ChromeOptions();
            //options.AddArgument("start-maximized");
            //driver = new ChromeDriver(options);
        }

        [TestMethod]
        public void Homework1()
        {
            //driver.Navigate().GoToUrl("http://158.101.173.161/admin");

            //if (driver.FindElements(By.Name("query")).Count == 0)
            //{
            //    driver.FindElement(By.Name("username"), 1000).SendKeys("testadmin");
            //    driver.FindElement(By.Name("password"), 1000).SendKeys("testadmin" + Keys.Enter);
            //}

            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("box-apps-menu")));
            //Thread.Sleep(1000);

            //for (int i = 1; i <= driver.FindElements(By.ClassName("app")).Count; i++)
            //{
            //    driver.FindElement(By.XPath($"//li[contains(@class, 'app')][{i}]")).Click();
            //    Assert.IsTrue(driver.FindElement(By.ClassName("panel-heading")).Displayed, "Panel-heading not found!");

            //    for (int j = 1; j <= driver.FindElements(By.ClassName("doc")).Count; j++)
            //    {
            //        driver.FindElement(By.XPath($"//li[contains(@class, 'doc')][{j}]")).Click();
            //        Assert.IsTrue(driver.FindElement(By.ClassName("panel-heading")).Displayed, "Panel-heading not found!");
            //    }
            //}
        }

        [TestMethod]
        public void Homework2()
        {
            //int itemQty = 3;
            //AddRandomPopularItemToCart(itemQty);
            //Assert.AreEqual(itemQty.ToString(), driver.FindElement(By.CssSelector("#cart .badge.quantity"), 2000).Text);

            //NavigateToCart();

            //RemoveAllItemsFromCart();
            
            //driver.FindElement(By.CssSelector("#box-checkout .btn.btn-default"), 2000).Click();
            //Assert.AreEqual("", driver.FindElement(By.CssSelector("#cart .badge.quantity"), 2000).Text);
        }

        [TestMethod]
        public void Homework4()
        {
            App app = new App();

            app.OpenHomePage();
            int currentCartQtyBeforeAdding = app.homePage.GetCartQty();
            
            app.homePage.AddRandomPopularItemToCart(3);
            Assert.AreEqual(currentCartQtyBeforeAdding + 3, app.homePage.GetCartQty());
            
            app.OpenCartPage();
            app.cartPage.RemoveAllProductsFromCart();

            app.OpenHomePage();
            Assert.AreEqual(0, app.homePage.GetCartQty());

            app.Quit();
        }

        [TestCleanup]
        public void TearDown()
        {
            //driver.Close();
            //driver.Dispose();
        }

        //public void AddRandomPopularItemToCart(int itemQty)
        //{
        //    for (int i = 0; i < itemQty; i++)
        //    {
        //        driver.Navigate().GoToUrl("http://158.101.173.161");
        //        int qty;

        //        var currentQtyInCart = driver.FindElement(By.CssSelector("#cart .badge.quantity"), 2000).Text;

        //        if (string.IsNullOrEmpty(currentQtyInCart))
        //        {
        //            qty = 0;
        //        }
        //        else
        //        {
        //            qty = Int32.Parse(currentQtyInCart);
        //        }

        //        var count = driver.FindElements(By.CssSelector("#box-popular-products > .listing.products > .product-column")).Count;
        //        Random rnd = new Random();
        //        int a = rnd.Next(1, count);
        //        driver.FindElement(By.Id("box-popular-products")).FindElement(By.CssSelector($"#box-popular-products > .listing.products > .product-column:nth-child({a})")).Click();
        //        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        //        _ = (string)js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.Name("add_cart_product")));

        //        wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(5000));

        //        Actions actions = new Actions(driver);
        //        var elementLocator = driver.FindElement(By.Name("add_cart_product"), 2000);
        //        actions.Click(elementLocator).Perform();

        //        _ = (string)js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.CssSelector("#cart"), 2000));

        //        _ = wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#cart .badge.quantity"), (qty + 1).ToString()));
        //    }            
        //}

        //public void NavigateToCart()
        //{
        //    driver.FindElement(By.CssSelector("#cart")).Click();
        //    driver.FindElement(By.Id("box-checkout-cart"), 2000);
        //}

        //public void RemoveAllItemsFromCart()
        //{
        //    var count = driver.FindElements(By.Name("remove_cart_item")).Count;

        //    while (count > 0)
        //    {
        //        driver.FindElement(By.Name("remove_cart_item"), 5000).Click();
        //        wait.Until(ExpectedConditions.StalenessOf(driver.FindElement(By.ClassName("loader"), 2000)));
        //        count--;
        //    }

        //    wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#box-checkout p"), "There are no items in your cart."));
        //}
    }
}
