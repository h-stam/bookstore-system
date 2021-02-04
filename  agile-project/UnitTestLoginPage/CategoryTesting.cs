using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStoreTests
{
    [TestClass]
    public class CategoryTesting
    {
        DALCategory dalCategory = new DALCategory();
        List<Category> categories;

        [TestMethod]
        public void TestGetAllCategories()
        {
            categories = dalCategory.GetAllCategories();

            Boolean expectedReturn = true;

            Boolean actualReturn = categories.Count > 0;

            Assert.AreEqual(expectedReturn, actualReturn);
        }
    }
}
