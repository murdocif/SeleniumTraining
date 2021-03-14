using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTraining
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInMilliseconds)
        {
            if (timeoutInMilliseconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeoutInMilliseconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }
    }
}
