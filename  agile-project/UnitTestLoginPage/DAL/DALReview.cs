using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace BookStoreTests
{
    public class DALReview
    {
        public bool AddReviewItem(ReviewItem reviewItem, int UserID, string ISBN)
        {
            if (reviewItem != null && UserID > 0 && ISBN.Length > 0)
                return true;
            return false;
        }


        public bool GetReviewByKey(ReviewItem reviewItem, int UserID, string ISBN)
        {
            if (reviewItem != null && UserID > 0 && ISBN.Length > 0)
                return true;
            return false;
        }


        public bool getISBNFromTitle(string title)
        {
            if (title.Length > 0)
                return true;
            return false;
        }

        public bool GetBookTitles(List<string> titles)
        {
            if (titles.Count > 0)
                return true;
            return false;
        }

        public bool GetAllReviewsForISBN(List<ReviewItem> reviews, string ISBN)
        {
            if (reviews.Count > 0 && ISBN.Length > 0)
                return true;
            return false;
        }


    }

}

