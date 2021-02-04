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

namespace BookStoreGUI
{

    public partial class LoginDialog : Window
    {
        public Principle CurrentUser;

        public LoginDialog()
        {
            CurrentUser = new Principle();
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            String Username = nameTextBox.Text;
            String Password = passwordTextBox.Password;
            UserPrincipleDAL UserPrincipleDAL = new UserPrincipleDAL();

            if (checkPassword(Password))
            {
                Principle Attempt = UserPrincipleDAL.LogIn(Username, Password);
                if(Attempt == null)
                {
                    MessageBox.Show("Could not validate your credentials.");
                    DialogResult = false;
                } else
                {
                    MessageBox.Show("Welcome to BookStore!");
                    CurrentUser.ID = Attempt.ID;
                    CurrentUser.Username = Attempt.Username;
                    DialogResult = true;
                    this.Close();
                }
            } else
            {
                MessageBox.Show("Please enter valid credentials.");
            }
        }

        private bool checkPassword(string Password)
        {
            return (Password.Any(char.IsLetter) &&
                    Password.Any(char.IsDigit) &&
                    Password.Length >= 6) &&
                    char.IsLetter(Password.First());
        }

    }
}
