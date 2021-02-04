using System;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStoreTests
{
    [TestClass]
    public class AddButtonTesting
     {
        ObservableCollection<OrderItem> Order = new ObservableCollection<OrderItem>();
        String isbn;
        String title;
        double unitPrice;
        int quantity;

        //The intent of this method is to check if you can add a book to the Order List
        [TestMethod]
        public void TestAddBook()
        {
            isbn = "123";
            title = "How To Cook";
            unitPrice = 3.99f;
            quantity = 2;
            OrderItem orderItem = new OrderItem(isbn, title, unitPrice, quantity);
            Order.Add(orderItem);

            Boolean expectedReturn = true;

            Boolean actualReturn = Order.Contains(orderItem);

            Assert.AreEqual(expectedReturn, actualReturn);
        }

        //To check if it's possible to remove a book from the order list
        [TestMethod]
        public void TestRemoveBook()
        {
            isbn = "123";
            title = "How To Cook";
            unitPrice = 3.99f;
            quantity = 2;
            OrderItem orderItem = new OrderItem(isbn, title, unitPrice, quantity);
            Order.Remove(orderItem);

            Boolean expectedReturn = false;

            Boolean actualReturn = Order.Contains(orderItem);

            Assert.AreEqual(expectedReturn, actualReturn);
        }
    }
}
