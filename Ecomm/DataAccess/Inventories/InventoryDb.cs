using Dapper;
using Ecomm.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ecomm.DataAccess.Inventories
{
    public class InventoryDb : IInventoryDb
    {
        private readonly string _connectionString;

        public InventoryDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Inventory[] Get()
        {
            using var connection = new SqlConnection(_connectionString);
            const string query = @"SELECT Id, Name, Quantity, ProductId FROM Inventory";
            return connection.Query<Inventory>(query).ToArray();
        }

        public async Task Update(OrderRequest orderRequest)
        {
            using var connection = new SqlConnection(_connectionString);
            try
            {
                var inventory = new { name = orderRequest.ProductName, orderRequest.Quantity, orderRequest.ProductId };
                await connection.ExecuteAsync("UPDATE_INVENTORY", inventory, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
