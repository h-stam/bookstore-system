using System;
using System.Collections.Generic;
using System.Text;
using BookStoreDomain;
using System.Data.SqlClient;
using BookStoreDAL.Properties;
using System.Data;

namespace BookStoreDAL
{
    public class CategoryDAL
    {

        SqlConnection _Connection;

        public CategoryDAL()
        {
            _Connection = new SqlConnection(Resources.ConnectionString);
        }

        public Category GetCategoryByID(String ISBN)
        {

            Category Result = new Category();

            SqlCommand Command = new SqlCommand("GetCategoryByID", _Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@CategoryID", ISBN));
            using (SqlDataReader reader = Command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Result.ID = (int)reader["category"];
                    Result.Title = (String)reader["name"];
                }
            }

            return Result;

        }

        public List<Category> GetAllCategories()
        {

            List<Category> Result = new List<Category>();

            _Connection.Open();

            SqlCommand Command = new SqlCommand("GetAllCategories", _Connection);
            Command.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader reader = Command.ExecuteReader())
            {
                while (reader.Read())
                {

                    Category Category = new Category();

                    Category.ID = (int)reader["categoryid"];
                    Category.Title = (String)reader["name"];

                    Result.Add(Category);
                }
            }

            _Connection.Close();

            return Result;

        }
    }
}
