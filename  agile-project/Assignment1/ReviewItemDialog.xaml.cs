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
    public partial class ReviewItemDialog : Window
    {
   //     SqlConnection _Connection;
        public Principle CurrentUser;
        string title;

        public ReviewItemDialog(Principle CurrentUserEntered)//String title, int Rating, String comments)
        {
            CurrentUser = CurrentUserEntered;

            InitializeComponent();
            fillBookTitleComboBox();
        }
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            ReviewDAL ReviewDAL = new ReviewDAL();
           
            int userID = CurrentUser.ID;
           // String title = fillBookTitleComboBox.SelectedItem.Content.toString();
            String title = bookTitleComboBox.SelectedItem.ToString().Trim();
            String ISBN = ReviewDAL.getISBNFromTitle(title);

           // MessageBox.Show(ReviewDAL.getISBNFromTitle(title) + "\n" + title + "\n" + bookTitleComboBox.Text + "\n" + bookTitleComboBox.SelectedItem.ToString());

            int rating = Int32.Parse(ratingDropDown.Text);
            String comment = commentsTextBox.Text;

            ReviewItem review = new ReviewItem(ISBN, userID, rating, comment);

            ReviewDAL.AddReviewItem(review);
            MessageBox.Show("Thank you for your feedback.\n YOUR SUBMISSION: \n User: " + userID + "\n ISBN: " + ISBN + "\n Rating/5: " + rating + "\n Comments: " + comment);
            
            //ReviewDAL.closeConnection();

            this.DialogResult = true;
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void fillBookTitleComboBox() {
            ReviewDAL ReviewDAL = new ReviewDAL();
            
            try
            {
                List<String> titles = ReviewDAL.GetBookTitles();
                foreach (String title in titles) {
                    bookTitleComboBox.Items.Add(title);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
            //ReviewDAL.closeConnection();

        }
    }
}
