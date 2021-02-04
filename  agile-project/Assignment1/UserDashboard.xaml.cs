using BookStoreDAL;
using BookStoreDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookStoreGUI
{
    /// <summary>
    /// Interaction logic for UserDashboard.xaml
    /// </summary>
    public partial class UserDashboard : Window
    {

        Principle _CurrentUser;

        OrderItemDAL OrderItemDAL;
        List<OrderItem> _OrderItems;

        public UserDashboard(Principle currentUser)
        {
            _CurrentUser = currentUser;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _OrderItems = new List<OrderItem>();
            OrderItemDAL = new OrderItemDAL();
            _OrderItems = OrderItemDAL.GetOrderItemsByUserID(_CurrentUser.ID);

            UserLabel.Content = _CurrentUser.Username;

            PreviousOrders.ItemsSource = _OrderItems;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {}

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
