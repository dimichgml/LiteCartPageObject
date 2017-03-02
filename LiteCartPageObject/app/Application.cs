using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace LiteCart_PageObject
{
    public class Application
    {
        private IWebDriver driver;
        private MainStorePage mainStorePage;
        private ItemPage itemPage;
        private CartPage cartPage;


        public Application()
        {
            driver = new ChromeDriver();           
            mainStorePage = new MainStorePage(driver);
            itemPage = new ItemPage(driver);
            cartPage = new CartPage(driver);
        }

        public void Quit()
        {
            driver.Quit();
        }

        internal void ToFillCart(Order order)
        {           
            /*
             * Открываем главнуют страницу, Выбираем первый товар, ожидаем загрузки страницы товара
             * Если у товара есть элмент выбора размера, выбираем размер, добвляем товар в коризину
             * Ожидаем обновления количества товаров в корзине
             */
            mainStorePage.Open();
            mainStorePage.GoogsItem.Click();
            itemPage.WaitPageLoaded();
            if (itemPage.IsSizeChooseAvalible())
            {
                itemPage.SelectSize(order.Size);
            }
            itemPage.AddToCartBtn.Click();                            
            itemPage.WaitCartFill(itemPage.GoogsCount,itemPage.GetGoogsCount());
        }

        internal void RemoveGoods()
        {      
            /*Открываем главную страницу магазина, открываем корзину, Пока в таблице строк больше, чем 0 выполняем удаление товаров. 
             * После каждого удаления ожидаем обновления таблицы
             */                  
            mainStorePage.Open();            
            cartPage.Open();
            cartPage.WaitPageLoaded();
            while (cartPage.GetRowsTableCount() > 0)
            {
                cartPage.RemoveCartItemBtn.Click();
                cartPage.WaitItemDelete(cartPage.GetRowsTableCount());
            }                          
        }
    }
}
