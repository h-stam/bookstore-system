using System;
using System.Collections.Generic;
using System.Text;
using BookStoreDomain;
using System.Data.SqlClient;
using BookStoreDAL.Properties;
using System.Data;
using System.Diagnostics;

namespace BookStoreDAL
{
    public class BookDAL
    {

        SqlConnection _Connection;

        public BookDAL()
        {
            _Connection = new SqlConnection(Resources.ConnectionString);
        }

        public Book GetBookByID(String ISBN)
        {

            Book Result = new Book();

            SqlCommand Command = new SqlCommand("GetBookByID", _Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@BookID", ISBN));
            using (SqlDataReader reader = Command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Result.ISBN = (String)reader["isbn"];
                    Result.Title = (String)reader["title"];
                    Result.Year = (Int64)reader["year"];
                    Result.Publisher = (String)reader["publisher"];
                    Result.Author = (String)reader["author"];
                    Result.Edition = (Int64)reader["edition"];
                }
            }

            return Result;

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
