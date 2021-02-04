using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;

namespace BookStoreTests
{
    class DALUserPrinciple
    {

        SqlConnection _Connection;
        public DALUserPrinciple()
        {
            _Connection = new SqlConnection(Properties.Settings.Default.haConnection);
        }

        public Principle LogIn(String Username, String Password)
        {
            Principle Result = new Principle();

            _Connection.Open();

            SqlCommand Command = new SqlCommand("GetUserByUsername", _Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@username", Username));
            using (SqlDataReader reader = Command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Result.ID = (int)reader["userid"];
                    Result.Username = (String)reader["username"];
                    Result.Password = (String)reader["password"];
                }
            }

            _Connection.Close();

            if (Result.Password != Password)
            {
                return null;
            }

            return Result;
        }

       /* public int SignUp(String username, String password)
        {

            int UserID;

            _Connection.Open();
            SqlCommand Command = new SqlCommand("SignUp", _Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@UserName", username));
            Command.Parameters.Add(new SqlParameter("@Password", password));
            Command.Parameters.Add("@UserID", SqlDbType.Int).Direction = ParameterDirection.Output;
            Command.ExecuteNonQuery();
            UserID = Convert.ToInt32(Command.Parameters["@UserID"].Value);
            _Connection.Close();

            return UserID;

        } */
    }
}
