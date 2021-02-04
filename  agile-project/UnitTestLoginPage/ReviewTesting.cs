using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStoreTests
{
    [TestClass]
    public class ReviewTesting
    {
        DALReview dalReview = new DALReview();
        ReviewItem reviewItem;

        [TestMethod]
        public void TestAddReviewItem()
        {
            reviewItem = new ReviewItem("1234567890", 2, 3, "Test");
            Boolean expectedReturn = true;
            Boolean actualReturn = dalReview.AddReviewItem(reviewItem, 2, "1234567890");
            Assert.AreEqual(expectedReturn, actualReturn);
        }


        [TestMethod]
        public void TestGetReviewByKey()
        {
            reviewItem = new ReviewItem("1234567890", 2, 3, "Test");
            Boolean expectedReturn = true;
            Boolean actualReturn = dalReview.GetReviewByKey(reviewItem, 2, "1234567890");
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestGetISBNFromTitle()
        {
            string tester = "Test";
            Boolean expectedReturn = true;
            Boolean actualReturn = dalReview.getISBNFromTitle(tester);
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestGetBookTitles()
        {

            List<string> titles = new List<string>();
            titles.Add("test");
            Boolean expectedReturn = true;
            Boolean actualReturn = dalReview.GetBookTitles(titles);
            Assert.AreEqual(expectedReturn, actualReturn);
        }


        [TestMethod]
        public void TestGetAllReviewsForISBN()
        {
            List<ReviewItem> tester = new List<ReviewItem>();
            reviewItem = new ReviewItem("1234567890", 2, 3, "Test");
            tester.Add(reviewItem);
            Boolean expectedReturn = true;
            Boolean actualReturn = dalReview.GetAllReviewsForISBN(tester, "1234567890");
            Assert.AreEqual(expectedReturn, actualReturn);
        }
    }
}
