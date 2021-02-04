/* **********************************************************************************
 * For use by students taking 60-422 (Fall, 2014) to work on assignments and project.
 * Permission required material. Contact: xyuan@uwindsor.ca 
 * **********************************************************************************/
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
using System.Data;
using System.Collections.ObjectModel;
using BookStoreDomain;
using BookStoreDAL;

namespace BookStoreGUI
{
    /// Interaction logic for MainWindow.xaml
    public partial class MainWindow : Window
    {

        BookDAL BookDAL;
        OrderDAL OrderDAL;
        LoginDialog LoginDialog;
        UserDashboard UserDashboard;
        RegisterUser RegisterUser;


        Principle CurrentUser;
        List<Book> Catalog;
        List<Category> Categories;
        ObservableCollection<OrderItem> Order;

        public MainWindow() { InitializeComponent(); }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            //This must be called here in order to get rid of the login bug error
            LoginDialog = new LoginDialog();
            LoginDialog.ShowDialog();

            if (LoginDialog.DialogResult == true)
            {
                CurrentUser.ID = LoginDialog.CurrentUser.ID;
                CurrentUser.Username = LoginDialog.CurrentUser.Username;

                addButton.IsEnabled = true;
                removeButton.IsEnabled = true;
                reviewButton.IsEnabled = true;
                checkoutOrderButton.IsEnabled = true;
                loginButton.IsEnabled = false;

                UserDashboard.IsEnabled = true;

                RegisterUser.IsEnabled = false;

                statusTextBlock.Text = "You are logged in as: " + CurrentUser.Username;
            }
            else { loginButton.IsEnabled = true; }

        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CurrentUser = new Principle();
            RegisterUser = new RegisterUser();
            UserDashboard = new UserDashboard(CurrentUser);
            OrderDAL = new OrderDAL();

            BookDAL = new BookDAL();
            Catalog = BookDAL.GetAllBooks();
            booksListView.ItemsSource = Catalog;

            Order = new ObservableCollection<OrderItem>();
            orderListView.ItemsSource = Order;

            CategoryDAL CategoryDAL = new CategoryDAL();
            Categories = CategoryDAL.GetAllCategories();
            categoriesComboBox.ItemsSource = Categories.Select(c => c.Title);
                
            GrandTotalBox.Text = "";
            addButton.IsEnabled = false;
            removeButton.IsEnabled = false;
            checkoutOrderButton.IsEnabled = false;
            reviewButton.IsEnabled = false;
            UserDashboard.IsEnabled = false;
        }

        private void checkoutButton_Click(object sender, RoutedEventArgs e)
        {
            int OrderID = OrderDAL.AddOrder(CurrentUser.ID);
            OrderDAL.AddOrderItems(Order, OrderID);
            MessageBox.Show("Your order has been placed. Your order id is " + OrderID.ToString());
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Book SelectedItem = (Book)booksListView.SelectedItem;

            if(SelectedItem == null)
            {
                MessageBox.Show("You must select a book! ");
            }
            else
            {
                OrderItemDialog OrderItemDialog = new OrderItemDialog(SelectedItem.ISBN, SelectedItem.Title, SelectedItem.Price);
                OrderItemDialog.ShowDialog();

                if (OrderItemDialog.DialogResult == true)
                {
                    for (int i = 0; i < Order.Count; i++)
                    {
                        if (Order[i].BookID == SelectedItem.ISBN)
                        {
                            Order[i] = new OrderItem(SelectedItem.ISBN, SelectedItem.Title, SelectedItem.Price, Order[i].Quantity + int.Parse(OrderItemDialog.quantityTextBox.Text));
                            return;
                        }
                    }
                    Order.Add(new OrderItem(SelectedItem.ISBN, SelectedItem.Title, SelectedItem.Price, int.Parse(OrderItemDialog.quantityTextBox.Text)));
                }

                GrandTotalBox.Text = OrderDAL.CalcGrandTotal(Order).ToString();
            }

        }
        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            OrderItem SelectedItem = (OrderItem)orderListView.SelectedItem;
            Order.Remove(SelectedItem);
            GrandTotalBox.Text = OrderDAL.CalcGrandTotal(Order).ToString();
        }

        private void reviewButton_Click(object sender, RoutedEventArgs e) {

            ReviewItemDialog ReviewItemDialog = new ReviewItemDialog(CurrentUser);
            ReviewItemDialog.ShowDialog();
        
        }

        private void viewReviewsButton_Click(object sender, RoutedEventArgs e)
        {
            //   try
            //  {
            Book SelectedItem = new Book();
            if (booksListView.SelectedItem != null)
                SelectedItem = (Book)booksListView.SelectedItem;

            ViewReviewsDialog ViewReviewsDialog = new ViewReviewsDialog(SelectedItem);
            ViewReviewsDialog.ShowDialog();
            /*  }
              catch (Exception ex) {

              }//*/
        }

        private void categoriesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Catalog = BookDAL.GetBooksByCategory((string)categoriesComboBox.SelectedItem);
            booksListView.ItemsSource = Catalog;
        }


        private void userDashboard_Click(object sender, RoutedEventArgs e)
        {
            UserDashboard = new UserDashboard(CurrentUser);
            UserDashboard.ShowDialog();
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            RegisterUser = new RegisterUser();
            RegisterUser.ShowDialog();

            if (RegisterUser.DialogResult == true)
            {
                CurrentUser.ID = RegisterUser.CurrentUser.ID;
                CurrentUser.Username = RegisterUser.CurrentUser.Username;

                addButton.IsEnabled = true;
                removeButton.IsEnabled = true;
                checkoutOrderButton.IsEnabled = true;
                loginButton.IsEnabled = false;
                RegisterUser.IsEnabled = false;

                statusTextBlock.Text = "You are logged in as: " + CurrentUser.Username;
            }

        }

        private void previewButton_Click(object sender, RoutedEventArgs e)
        {
            Book SelectedItem = (Book)booksListView.SelectedItem;
            String ISBN;
            String bookName;
            String author;
            String genre;

            if (SelectedItem != null)
            {
                bookName = SelectedItem.Title;
                ISBN = SelectedItem.ISBN;
                author = SelectedItem.Author;
                genre = categoriesComboBox.SelectedItem.ToString();

                BookPreviewer bookPreviewWindow = new BookPreviewer(bookName, ISBN, author, genre);

                bookPreviewWindow.ShowDialog();

            }
        }
    }
}
