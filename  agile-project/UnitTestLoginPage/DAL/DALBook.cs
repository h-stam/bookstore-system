using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace BookStoreTests
{
    public class DALBook
    {
        SqlConnection _Connection;
        public DALBook()
        {
            _Connection = new SqlConnection(Properties.Settings.Default.haConnection);
        }

        public List<Book> GetAllBooks()
        {

            List<Book> Result = new List<Book>();

            _Connection.Open();

            SqlCommand Command = new SqlCommand("GetAllBooks", _Connection);
            Command.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader reader = Command.ExecuteReader())
            {
                while (reader.Read())
                {

                    Book Book = new Book();

                    Book.ISBN = (String)reader["isbn"];
                    Book.Title = (String)reader["title"];
                    Book.Year = (int)reader["year"];
                    Book.Publisher = (String)reader["publisher"];
                    Book.Author = (String)reader["author"];
                    Book.Edition = (int)reader["edition"];
                    Book.Price = (decimal)reader["price"];

                    Result.Add(Book);
                }
            }

            _Connection.Close();

            return Result;

        }

        public List<Book> GetBooksByCategory(string Category)
        {

            List<Book> Result = new List<Book>();

            _Connection.Open();

            SqlCommand Command = new SqlCommand("GetBooksByCategory", _Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@Category", Category));
            using (SqlDataReader reader = Command.ExecuteReader())
            {
                while (reader.Read())
                {

                    Book Book = new Book();

                    Book.ISBN = (String)reader["isbn"];
                    Book.Title = (String)reader["title"];
                    Book.Year = (int)reader["year"];
                    Book.Publisher = (String)reader["publisher"];
                    Book.Author = (String)reader["author"];
                    Book.Edition = (int)reader["edition"];
                    Book.Price = (decimal)reader["price"];

                    Result.Add(Book);
                }
            }

            _Connection.Close();

            return Result;

        }
    }
}
