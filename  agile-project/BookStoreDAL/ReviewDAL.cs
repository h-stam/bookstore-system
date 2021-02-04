using System;
using System.Collections.Generic;
using System.Text;
using BookStoreDomain;
using System.Data.SqlClient;
using BookStoreDAL.Properties;
using System.Data;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace BookStoreDAL
{
    public class ReviewDAL
    {

        SqlConnection _Connection;

        public ReviewDAL()
        {
            _Connection = new SqlConnection(Resources.ConnectionString);
            _Connection.Open();
        }

        public ReviewItem GetReviewByKey(int UserID, String ISBN)
        {
            ReviewItem Result = new ReviewItem();

            _Connection = new SqlConnection(Resources.ConnectionString);
            _Connection.Open();// _Connection.Open();

            SqlCommand Command = new SqlCommand("GetReviewByKey", _Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@UserID", UserID));
            Command.Parameters.Add(new SqlParameter("@ISBN", ISBN));
            using (SqlDataReader reader = Command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Result.ISBN = (String)reader["ISBN"];
                    Result.UserID = (int)reader["UserID"];
                    Result.Rating = (int)reader["Rating"];
                    Result.Comment = (String)reader["Comment"];
                }
            }

            _Connection.Close();

            return Result;
        }

        public String getISBNFromTitle(String title) {
            _Connection = new SqlConnection(Resources.ConnectionString);
            _Connection.Open();//  _Connection.Open();
            String ISBN = "";

            SqlCommand Command = new SqlCommand("findISBN", _Connection);
            Command.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter();
           /*parameter.ParameterName = "@Title";
            parameter.SqlDbType = SqlDbType.NVarChar;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = title;
            Command.Parameters.Add(parameter);
           */

            Command.Parameters.Add(new SqlParameter("@Title", title));

            using (SqlDataReader reader = Command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ISBN = (String)reader["ISBN"];
                }
            }

            _Connection.Close();

            return ISBN;
        }

        public List<String> GetBookTitles() {
            _Connection = new SqlConnection(Resources.ConnectionString);
            _Connection.Open();//   _Connection.Open();
            List<String> Result = new List<String>();
            SqlCommand Command = new SqlCommand("GetBookTitles", _Connection);
            using (SqlDataReader reader = Command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string title = (String)reader["Title"];
                    Result.Add(title);
                }
            }

            _Connection.Close();
            
            return Result;

        }

        public List<ReviewItem> GetAllReviewsForISBN(string ISBN)
        {
            _Connection = new SqlConnection(Resources.ConnectionString);
            _Connection.Open();//   _Connection.Open();

            List<ReviewItem> Result = new List<ReviewItem>();

            SqlCommand Command = new SqlCommand("GetAllReviewsForISBN", _Connection);
            Command.CommandType = CommandType.StoredProcedure;


           /* SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ISBN";
            parameter.SqlDbType = SqlDbType.NVarChar;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = ISBN;
            Command.Parameters.Add(parameter);
           */
            Command.Parameters.Add(new SqlParameter("@ISBN", ISBN));
            using (SqlDataReader reader = Command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ReviewItem Review = new ReviewItem();

                    Review.ISBN = (String)reader["ISBN"];
                    Review.UserID = (int)reader["UserID"];
                    Review.Rating = (int)reader["Rating"];
                    Review.Comment = (String)reader["Comment"];

                    Result.Add(Review);
                }
            }
            
            _Connection.Close();

            return Result;
            
        }

        public void AddReviewItem(ReviewItem reviewItem)
        {
            _Connection = new SqlConnection(Resources.ConnectionString);
            _Connection.Open();//   _Connection.Open();

            SqlCommand Command = new SqlCommand("AddReviewItem", _Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@ISBN", reviewItem.ISBN));
            Command.Parameters.Add(new SqlParameter("@UserID", reviewItem.UserID));
            Command.Parameters.Add(new SqlParameter("@Rating", reviewItem.Rating));
            Command.Parameters.Add(new SqlParameter("@Comment", reviewItem.Comment));

            _Connection.Close();
        }

        public void closeConnection() {
            if (_Connection != null && _Connection.State == ConnectionState.Open)   
                _Connection.Close();
        }
    }
}
