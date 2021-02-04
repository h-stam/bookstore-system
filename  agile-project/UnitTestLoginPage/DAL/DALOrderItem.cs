using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System;

namespace BookStoreTests
{
    public class DALOrderItem
    {
        SqlConnection _Connection;
        public DALOrderItem()
        {
            _Connection = new SqlConnection(Properties.Settings.Default.haConnection);
        }

        public List<OrderItem> GetOrderItemsByOrderID(int orderID)
        {
            List<OrderItem> Result = new List<OrderItem>();

            _Connection.Open();

            SqlCommand Command = new SqlCommand("GetOrderItemsByOrderID", _Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@OrderID", orderID));
            using (SqlDataReader reader = Command.ExecuteReader())
            {
                while (reader.Read())
                {
                    OrderItem orderItem = new OrderItem((String)reader["bookid"], (String)reader["booktitle"], Convert.ToSingle(reader["SubTotal"].ToString()), (int)reader["quantity"]);

                    Result.Add(orderItem);
                }
            }

            _Connection.Close();


            return Result;
        }
    }
}
