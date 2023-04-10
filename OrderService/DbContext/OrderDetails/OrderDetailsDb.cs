using Dapper;
using OrderService.Models;
using System.Data.SqlClient;
using System.Linq;

namespace OrderService.Orders
{
    public class OrderDetailsDb : IOrderDetailsDb
    {
        private readonly string _connectionString;

        public OrderDetailsDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        public OrderDetail[] Get()
        {
            using var connection = new SqlConnection(_connectionString);
            string query = @"SELECT o.UserName AS [User], od.ProductName AS Name, od.Quantity  
                             FROM [Order] o
                             JOIN [OrderDetail] od on o.Id = od.OrderId";
            return connection.Query<OrderDetail>(query).ToArray();
        }
    }
}
