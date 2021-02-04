using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BookStoreTests
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

        public string ISBN { get; set; }
        public int Rating { get; set; }
        public String Comment { get; set; }
        public int UserID { get; set; }

        public ReviewItem() { }

        public ReviewItem(String isbn, int userId, int rating,
            String comment)
        {
            ISBN = isbn;
            Rating = rating;
            Comment = comment;
            UserID = userId;
        }
        public override string ToString()
        {
            string xml = "<ReviewItem ISBN='" + ISBN + "'";
            xml += " UserID='" + UserID + "'";
            xml += " Rating='" + Rating + "'";
            xml += " Comment='" + Comment + "' />";
            return xml;
        }
    }
}

