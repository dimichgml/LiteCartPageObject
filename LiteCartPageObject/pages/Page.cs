﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LiteCart_PageObject
{
    internal class Page
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public Page(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }
    }
}
