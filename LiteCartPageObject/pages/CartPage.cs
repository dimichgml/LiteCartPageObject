using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace LiteCart_PageObject
{
    internal class CartPage : Page
    {
        public CartPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "button[name=remove_cart_item]")]
        internal IWebElement RemoveCartItemBtn;

        internal int GetRowsTableCount()
        {
            //Получаем количество строк с SKU товара в таблице.
            return driver.FindElements(By.CssSelector("table.dataTable.rounded-corners > tbody > tr > td.sku")).Count;
        }

        internal CartPage Open()
        {
            driver.Url = "http://localhost/litecart/en/checkout";            
            return this;
        }

        internal void WaitPageLoaded()
        {
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("button[name=remove_cart_item]")));
        }

        internal void WaitItemDelete(int amountCart)
        {
            //Здесь использовал самописаное явное ожидание изменения количества строк с SKU товара в таблице. 
            int amountCart2;
            for (int i = 0; ; i++)
            {
                if (i >= 5)
                    throw new TimeoutException();
                amountCart2 = driver.FindElements(By.CssSelector("table.dataTable.rounded-corners > tbody > tr > td.sku")).Count;
                if (amountCart2 == amountCart - 1)
                {
                    amountCart = amountCart2;
                    break;
                }
                Thread.Sleep(1000);
            }
        }




    }
}
