using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace LiteCart_PageObject
{
    internal class MainStorePage : Page
    {
        public MainStorePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#cart > a.link")]
        internal IWebElement CartLink;

        internal MainStorePage Open()
        {
            driver.Url = "http://localhost/litecart/en/";
            return this;
        }

        internal MainStorePage OpenCart()
        {
            CartLink.Click();
            return this;
        }

        [FindsBy(How = How.CssSelector, Using = "#box-most-popular > div > ul > li:nth-child(1)")]
        internal IWebElement GoogsItem;      

        internal bool IsOnThisPage()
        {
            return driver.FindElements(By.CssSelector("#box-most-popular > h3")).Count > 0;
        }

        [FindsBy(How = How.CssSelector, Using = "span.quantity")]
        internal IWebElement GoogsCount;

        internal int GetGoogsCount()
        {
            return Int32.Parse(GoogsCount.GetAttribute("textContent").ToString());
        }
    }
}
