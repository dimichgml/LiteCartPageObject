using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LiteCart_PageObject
{
    [TestFixture]
    public class CartTests : TestBase
    {
        [Test, TestCaseSource(typeof(DataProviders), "ValidOrders")]
        public void CanAddGoogdsToCart(Order order)
        {
            for (int i = 0; i < order.AmountGoogs; i++)
            {          
                app.ToFillCart(order);  
            }
            app.RemoveGoods();
        }
    }
}
