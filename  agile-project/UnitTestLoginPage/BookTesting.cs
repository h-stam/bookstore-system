using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStoreTests
{
    [TestClass]
    public class BookTesting
    {
        DALBook dalBook = new DALBook();
        List<Book> books;
        Category category;

        [TestMethod]
        public void TestGetAllBooks()
        {
            books = dalBook.GetAllBooks();

            Boolean expectedReturn = true;

            Boolean actualReturn = books.Count > 0;

            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestGetBooksByCategory()
        {
            category = new Category { ID = 1, Title = "Fiction" };

            books = dalBook.GetBooksByCategory(category.Title);

            Boolean expectedReturn = true;

            Boolean actualReturn = books.Count > 0;

            Assert.AreEqual(expectedReturn, actualReturn);
        }
    }
}
