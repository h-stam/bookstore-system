using System;
using System.ComponentModel;

namespace BookStoreDomain
{
    public class OrderItem : INotifyPropertyChanged
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

        public string BookID { get; set; }
        public string BookTitle { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }
        public int OrderID { get; set; }

        public OrderItem() { }
        public decimal GrandTotal { get; set; }

        public OrderItem(String isbn, String title,
            decimal unitPrice, int quantity)
        {
            BookID = isbn;
            BookTitle = title;
            UnitPrice = unitPrice;
            Quantity = quantity;
            SubTotal = UnitPrice * Quantity;
        }
    }
}