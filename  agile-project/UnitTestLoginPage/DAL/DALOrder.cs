using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System;

namespace BookStoreTests
{
    public class DALOrder
    {
        SqlConnection _Connection;
        public DALOrder()
        {
            _Connection = new SqlConnection(Properties.Settings.Default.haConnection);
        }

        public bool AddOrderItems(ObservableCollection<OrderItem> orderItems, int OrderID)
        {
            if (orderItems != null && OrderID > 0)
                return true;
            return false;
        }

        public bool AddOrder(int userID)
        {
            if (userID > 0)
                return true;
            return false;
        }

        public List<Order> GetOrdersByUserID(int userID)
        {
            List<Order> Result = new List<Order>();


            _Connection.Open();

            SqlCommand Command = new SqlCommand("GetOrdersByUserID", _Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@UserID", userID));
            using (SqlDataReader reader = Command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Order order = new Order();
                    Principle user = new Principle();
                    Book book = new Book();

                    order.ID = (int)reader["orderid"];

                    book.ISBN = (String)reader["isbn"];
                    book.Title = (String)reader["title"];
                    book.Year = (int)reader["year"];
                    book.Publisher = (String)reader["publisher"];
                    book.Author = (String)reader["author"];
                    book.Edition = (int)reader["edition"];
                    book.Price = (decimal)reader["price"];

                    user.ID = (int)reader["userid"];
                    user.Username = (String)reader["username"];
                    user.Password = (String)reader["password"];

                    if (Result.Any(o => o.ID == order.ID))
                    {
                        int index = Result.FindIndex(o => o.ID == order.ID);
                        Result[index].Books.Add(book);
                        Result[index].Total += Convert.ToSingle(reader["SubTotal"].ToString());
                    }
                    else
                    {
                        order.Books = new List<Book>();
                        order.Books.Add(book);
                        order.Owner = user;
                        order.Total = Convert.ToSingle(reader["SubTotal"].ToString());
                        Result.Add(order);
                    }
                }
            }

            _Connection.Close();

            return Result;
        }

        public double CalcGrandTotal(ObservableCollection<OrderItem> orderItems, int OrderID)
        {
            double GrandTotal = 0;
            var list = new List<OrderItem>(orderItems);

            foreach (var item in list)
            {
                GrandTotal += item.SubTotal;
            }

            return GrandTotal;
        }
    }
}
