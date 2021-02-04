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
    /// <summary>
    /// Interaction logic for RegisterUser.xaml
    /// </summary>
    public partial class RegisterUser : Window
    {

        public Principle CurrentUser;

        public RegisterUser()
        {
            CurrentUser = new Principle();
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            String Username = unameTextBox.Text;
            String Password = passwordTextBox.Text;
            UserPrincipleDAL UserPrincipleDAL = new UserPrincipleDAL();

            if(Password == null || Password == "")
            {
                MessageBox.Show("Please write a password!");
            }
            else
            {
                if(Username == null || Username == "")
                {
                    MessageBox.Show("Please write a username!");
                }
                else
                {
                    if (checkPassword(Password))
                    {
                        Principle Attempt = UserPrincipleDAL.LogIn(Username, Password);
                        if (Attempt != null)
                        {
                            MessageBox.Show("Login information for " + Username + " already exists.");
                            //DialogResult = false;
                        }
                        else
                        {
                            int newUserId = UserPrincipleDAL.SignUp(Username, Password);
                            //  UserPrincipleDAL.LogIn(Username, Password);

                            MessageBox.Show("Welcome to BookStore! Your UserID is " + newUserId);
                            this.DialogResult = true;
                            this.Close();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter valid credentials.");
                    }
                }
            }
            
            
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

