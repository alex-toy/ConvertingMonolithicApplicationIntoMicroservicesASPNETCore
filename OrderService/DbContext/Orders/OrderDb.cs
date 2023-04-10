using Dapper;
using Microsoft.Extensions.Logging;
using OrderService.Models;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace OrderService.Orders
{
    public class OrderDb : IOrderDb
    {
        private readonly string _connectionString;
        private readonly ILogger<OrderDb> _logger;

        public OrderDb(string connectionString, ILogger<OrderDb> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }

        public async Task<int> Create(OrderDetail orderDetail)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var transaction = await connection.BeginTransactionAsync();
            try
            {
                var id = await connection.QuerySingleAsync<int>("CREATE_ORDER", new { userId = 1, userName = orderDetail.User }, transaction: transaction, commandType: System.Data.CommandType.StoredProcedure);
                await connection.ExecuteAsync("CREATE_ORDER_DETAILS",
                    new { orderId = id, productId = orderDetail.ProductId, quantity = orderDetail.Quantity, productName = orderDetail.ProductName }, transaction: transaction, commandType: System.Data.CommandType.StoredProcedure);
                transaction.Commit();
                return id;
            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                transaction.Rollback();
                return -1;
            }
        }

        public async Task Delete(int orderId)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction();
            try
            {
                await connection.ExecuteAsync("DELETE FROM OrderDetail WHERE OrderId = @orderId", new { orderId }, transaction: transaction);
                await connection.ExecuteAsync("DELETE FROM [Order] WHERE Id = @orderId", new { orderId }, transaction: transaction);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }
    }
}
