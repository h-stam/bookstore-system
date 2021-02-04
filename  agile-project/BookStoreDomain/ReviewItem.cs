using System;
using System.ComponentModel;

namespace BookStoreDomain
{
    public class ReviewItem : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        protected void Notify(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        #endregion

//        public int ReviewID { get; set; }
        public string ISBN { get; set; }
        public int Rating { get; set; }
        public String Comment { get; set; }
        public int UserID { get; set; }

        public ReviewItem() { }

        public ReviewItem(String isbn, int userId, int rating,
            String comment)
        {
//            ReviewID = reviewID;
            ISBN = isbn;
            Rating = rating;
            Comment = comment;
            UserID = userId;
        }
    }
}