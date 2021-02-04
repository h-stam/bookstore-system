/* **********************************************************************************
 * For use by students taking 60-422 (Fall, 2014) to work on assignments and project.
 * Permission required material. Contact: xyuan@uwindsor.ca 
 * **********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BookStoreDAL;
using BookStoreDomain;

using System.Data.SqlClient;


namespace BookStoreGUI
{
    /// <summary>
    /// Interaction logic for OrderItemDialog.xaml
    /// </summary>
    public partial class ViewReviewsDialog : Window
    {
        //     SqlConnection _Connection;
        Book book;
        public ViewReviewsDialog(Book book1)//String title, int Rating, String comments)
        {
            book = book1;
            InitializeComponent();
           /* if (book != null)
            {
                fillBookReviews(book);
            }
            else {
                showAllReviews();
            }*/
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            ReviewDAL ReviewDAL = new ReviewDAL();
         //   MessageBox.Show(ReviewDAL.getISBNFromTitle("sadf") + "0");

            try
            {
                if (book != null)
                {
                    fillBookReviews(book);
                }
                else
                {
                    showAllReviews();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void fillBookReviews(Book book) {
            if (book.ISBN != null && book.ISBN.Length > 0)
            {

                ReviewDAL ReviewDAL = new ReviewDAL();
               // MessageBox.Show(ReviewDAL.getISBNFromTitle("sadf") + "2");

                try
                {
                    List<ReviewItem> reviews = ReviewDAL.GetAllReviewsForISBN(book.ISBN);
                    ReviewsDisplay.ItemsSource = reviews;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else {
                showAllReviews();
            }

       //     ReviewDAL.closeConnection();
        }

       
        private void showAllReviews() {
            ReviewDAL ReviewDAL = new ReviewDAL();

         //   MessageBox.Show(ReviewDAL.getISBNFromTitle("sadf") + "1");

            try
            {
                List<String> books = ReviewDAL.GetBookTitles();
                List<ReviewItem> reviews = new List<ReviewItem>(); 
                foreach (String book in books)
                {
                    String ISBN = ReviewDAL.getISBNFromTitle(book);

                    List<ReviewItem> temp = ReviewDAL.GetAllReviewsForISBN(ISBN);

                    foreach (ReviewItem review in temp) {
                        reviews.Add(review);
                    }
                }

                ReviewsDisplay.ItemsSource = reviews;

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
          //  ReviewDAL.closeConnection();

        }
    }
}
