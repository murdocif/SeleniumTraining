using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumTraining.Application;

namespace SeleniumTraining.Pages
{
    class HomePage : Page
    {
        public HomePage(Context context) : base (context)
        {
        }

        public void AddRandomPopularItemToCart(int itemQty)
        {
            for (int i = 0; i < itemQty; i++)
            {                
                int qty;

                var currentQtyInCart = driver.FindElement(By.CssSelector("#cart .badge.quantity"), 2000).Text;

                if (string.IsNullOrEmpty(currentQtyInCart))
                {
                    qty = 0;
                }
                else
                {
                    qty = Int32.Parse(currentQtyInCart);
                }

                var count = driver.FindElements(By.CssSelector("#box-popular-products > .listing.products > .product-column")).Count;
                Random rnd = new Random();
                int a = rnd.Next(1, count);
                driver.FindElement(By.Id("box-popular-products")).FindElement(By.CssSelector($"#box-popular-products > .listing.products > .product-column:nth-child({a})")).Click();
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                _ = (string)js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.Name("add_cart_product")));

                wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(5000));

                Actions actions = new Actions(driver);
                var elementLocator = driver.FindElement(By.Name("add_cart_product"), 2000);
                actions.Click(elementLocator).Perform();

                _ = (string)js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.CssSelector("#cart"), 2000));

                _ = wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#cart .badge.quantity"), (qty + 1).ToString()));
                
                driver.Navigate().GoToUrl("http://158.101.173.161");
            }
        }

        public int GetCartQty()
        {
            var qty = driver.FindElement(By.CssSelector("#cart .badge.quantity"), 2000).Text;
            
            if (qty == "")
                return 0;
            else
                return Int32.Parse(qty);
        }
    }
}
