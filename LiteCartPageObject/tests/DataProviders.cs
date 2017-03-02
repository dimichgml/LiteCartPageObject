using System;
using System.Collections;

namespace LiteCart_PageObject
{
    class DataProviders
    {
        public static IEnumerable ValidOrders
        {
            get
            {
                yield return new Order()
                {
                    AmountGoogs = 3,
                    Size = "Small"
                };                
            }
        }
    }
}
