using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStoreTests
{
    [TestClass]
    public class OrderTesting
    {
        DALOrder dalOrder = new DALOrder();
        Order order;
        OrderItem orderItem;
        List<Order> orders = new List<Order>();
        OrderItem orderItem2;

        [TestMethod]
        public void TestAddOrder()
        {
            order = new Order();
            order.ID = 1;

            Boolean expectedReturn = true;

            Boolean actualReturn = dalOrder.AddOrder(order.ID);

            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestAddOrderItem()
        {
            order = new Order();
            order.ID = 1;

            orderItem = new OrderItem("1234567890", "Test", 1.00, 1);

            ObservableCollection<OrderItem> list = new ObservableCollection<OrderItem>();
            list.Add(orderItem);

            Boolean expectedReturn = true;

            Boolean actualReturn = dalOrder.AddOrderItems(list, order.ID);

            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestGetOrdersByUserID()
        {
            int userID = 1;

            orders = dalOrder.GetOrdersByUserID(userID);

            Boolean expectedReturn = true;
            Boolean actualRturn = orders.Count > 0;

            Assert.AreEqual(expectedReturn, actualRturn);
        }

        [TestMethod]
        public void TestCalcGrandTotal()
        {
            order = new Order();
            order.ID = 1;

            orderItem = new OrderItem("1234567890", "Test", 1.00, 1);
            orderItem2 = new OrderItem("012345678", "Test2", 2.00, 2);

            ObservableCollection<OrderItem> list = new ObservableCollection<OrderItem>();
            list.Add(orderItem);
            list.Add(orderItem2);

            Assert.AreEqual(5, dalOrder.CalcGrandTotal(list,order.ID));
        }
    }
}
