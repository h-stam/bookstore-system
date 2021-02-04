using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BookStoreDAL.Properties;
using BookStoreDomain;

namespace BookStoreDAL
{
    public class OrderItemDAL
    {

        SqlConnection _Connection;
        public OrderItemDAL()
        {
            _Connection = new SqlConnection(Resources.ConnectionString);
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
                    OrderItem orderItem = new OrderItem((String)reader["bookid"], (String)reader["booktitle"], Convert.ToDecimal(reader["unitprice"].ToString()), (int)reader["quantity"]);

                    Result.Add(orderItem);
                }
            }

            _Connection.Close();


            return Result;
        }

        public List<OrderItem> GetOrderItemsByUserID(int userID)
        {
            List<OrderItem> Result = new List<OrderItem>();


            _Connection.Open();

            SqlCommand Command = new SqlCommand("GetOrderItemsByUserID", _Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@UserID", userID));
            using (SqlDataReader reader = Command.ExecuteReader())
            {
                while (reader.Read())
                {
                    OrderItem OrderItem = new OrderItem();

                    OrderItem.OrderID = (int)reader["orderid"];
                    OrderItem.BookTitle = (String)reader["booktitle"];
                    OrderItem.Quantity = (int)reader["quantity"];
                    OrderItem.SubTotal = (decimal)reader["subtotal"];

                    Result.Add(OrderItem);

                }
            }

            _Connection.Close();

            return Result;
        }
    }
}
