using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SeleniumTraining.Application;

namespace SeleniumTraining.Pages
{
    class CartPage : Page
    {
        public CartPage(Context context) : base(context)
        {
        }

        internal void RemoveAllProductsFromCart()
        {
            var count = driver.FindElements(By.Name("remove_cart_item")).Count;

            while (count > 0)
            {
                driver.FindElement(By.Name("remove_cart_item"), 5000).Click();
                wait.Until(ExpectedConditions.StalenessOf(driver.FindElement(By.ClassName("loader"), 2000)));
                count--;
            }

            wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#box-checkout p"), "There are no items in your cart."));
        }
    }
}
