using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumTraining.Application;

namespace SeleniumTraining.Pages
{
    class Page
    {
        public IWebDriver driver;
        public WebDriverWait wait;
        Context context;

        public Page(Context context)
        {
            this.context = context;
            this.driver = context.GetDriver();
            this.wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(2000));
        }
    }
}
