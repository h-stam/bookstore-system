using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace BookStoreDomain
{
    public class Order : INotifyPropertyChanged
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

        public Int64 ID { get; set; }
        public List<Book> Books { get; set; }
        public float Total { get; set; }
        public Principle Owner { get; set; }
    }
}
