using System;
using System.Collections.Generic;
using System.Linq;
using BookStoreDomain;
using System.Data.SqlClient;
using BookStoreDAL.Properties;
using System.Data;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace BookStoreDAL
{
    public class OrderDAL
    {

        SqlConnection _Connection;

        public OrderDAL()
        {
            _Connection = new SqlConnection(Resources.ConnectionString);
        }

        public Order GetOrderByID(Int64 ID)
        {

            Order Result = new Order();

            SqlCommand Command = new SqlCommand("GetOrderByID", _Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@OrderID", ID));
            using (SqlDataReader reader = Command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Result.ID = (Int64)reader["id"];
                }
            }

            return Result;

        }

        public List<Order> GetAllOrders(Int64 ID)
        {

            List<Order> Result = new List<Order>();

            SqlCommand Command = new SqlCommand("GetAllOrdersByUser", _Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@UserID", ID));
            using (SqlDataReader reader = Command.ExecuteReader())
            {
                while (reader.Read())
                {

                    Order Order = new Order();

                    Order.ID = (Int64)reader["id"];

                    Result.Add(Order);
                }
            }

            return Result;

        }

        public void AddOrderItems(ObservableCollection<OrderItem> orderItems, int OrderID)
        {
            var list = new List<OrderItem>(orderItems);

            _Connection.Open();

            foreach (var item in list)
            {
                SqlCommand Command = new SqlCommand("AddOrderItem", _Connection);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Add(new SqlParameter("@BookID", item.BookID));
                Command.Parameters.Add(new SqlParameter("@BookTitle", item.BookTitle));
                Command.Parameters.Add(new SqlParameter("@UnitPrice", item.UnitPrice));
                Command.Parameters.Add(new SqlParameter("@Quantity", item.Quantity));
                Command.Parameters.Add(new SqlParameter("@SubTotal", item.SubTotal));
                Command.Parameters.Add(new SqlParameter("@OrderID", OrderID));
                Command.ExecuteNonQuery();
            }

            _Connection.Close();
        }

        public int AddOrder(int userID)
        {
            int OrderID;

            _Connection.Open();
            SqlCommand Command = new SqlCommand("AddOrder", _Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@UserID", userID));
            Command.Parameters.Add(new SqlParameter("@OrderDate", DateTime.Today));
            Command.Parameters.Add(new SqlParameter("@Status", 'P'));
            Command.Parameters.Add("@OrderID", SqlDbType.Int).Direction = ParameterDirection.Output;
            Command.ExecuteNonQuery();
            OrderID = Convert.ToInt32(Command.Parameters["@OrderID"].Value);
            _Connection.Close();
                
            return OrderID;
        }

        public decimal CalcGrandTotal(ObservableCollection<OrderItem> orderItems)
        {
            decimal GrandTotal = 0;
            var list = new List<OrderItem>(orderItems);

           foreach (var item in list)
            {
                GrandTotal += item.SubTotal;
            }

            return GrandTotal;
        }
    }
}
