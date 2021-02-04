using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStoreTests
{
    [TestClass]
    public class OrderItemTesting
    {
        DALOrderItem dalOrderItem = new DALOrderItem();
        List<OrderItem> orderItems = new List<OrderItem>();

        [TestMethod]
        public void TestOrderItemsByOrderID()
        {
            int orderID = 1;

            orderItems = dalOrderItem.GetOrderItemsByOrderID(orderID);

            Boolean expectedReturn = true;
            Boolean actualRturn = orderItems.Count > 0;

            Assert.AreEqual(expectedReturn, actualRturn);
        }
    }
}
