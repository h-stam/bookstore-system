using System;
using System.ComponentModel;

namespace BookStoreDomain
{
    public class Principle : INotifyPropertyChanged
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

        public int ID;
        public String Username;
        public String Password;
    }
}
