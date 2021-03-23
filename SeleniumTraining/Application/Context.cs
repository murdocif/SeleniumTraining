using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTraining.Application
{
    class Context
    {
        IWebDriver driver;
        WebDriverWait wait;
        string baseUrl = "http://158.101.173.161";

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public void SetDriver(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal void SetBaseUrl(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }
    }
}
