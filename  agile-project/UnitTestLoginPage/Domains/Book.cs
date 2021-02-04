using System;
using System.ComponentModel;

namespace BookStoreTests
{



    public class Book : INotifyPropertyChanged
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

        public String ISBN { get; set; }
        public String Title { get; set; }
        public String Author { get; set; }
        public Int64 Year { get; set; }
        public decimal Price { get; set; }
        public Int64 Edition { get; set; }
        public String Publisher { get; set; }
        public Category Category { get; set; }
    }
}
