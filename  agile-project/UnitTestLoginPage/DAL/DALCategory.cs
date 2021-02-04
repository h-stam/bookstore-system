using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace BookStoreTests
{
    public class DALCategory
    {

        SqlConnection _Connection;

        public DALCategory()
        {
            _Connection = new SqlConnection(Properties.Settings.Default.haConnection);
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
