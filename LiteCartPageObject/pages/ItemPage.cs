using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace LiteCart_PageObject
{
    internal class ItemPage : Page
    {
        public ItemPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "button[name=add_cart_product]")]
        internal IWebElement AddToCartBtn;

        internal void SelectSize(string size)
        {
            driver.FindElement(By.CssSelector("select[name='options[Size]']")).Click();            
            driver.FindElement(By.CssSelector("select[name='options[Size]'] > option[value*="+size+"]")).Click();
        }

        internal bool IsSizeChooseAvalible()
        {

            return driver.FindElements(By.CssSelector("select[name='options[Size]']")).Count > 0;
        }

        [FindsBy(How = How.CssSelector, Using = "span.quantity")]
        internal IWebElement GoogsCount;

        internal int GetGoogsCount()
        {
            return Int32.Parse(GoogsCount.GetAttribute("textContent").ToString());
        }

        internal void WaitCartFill(IWebElement googsCount, int count)
        {
            wait.Until(ExpectedConditions.TextToBePresentInElement(googsCount, (count + 1).ToString()));
        }

        internal void WaitPageLoaded()
        {
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("button[name=add_cart_product]")));
        }

    }
}
