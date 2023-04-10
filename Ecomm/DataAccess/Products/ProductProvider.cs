using Dapper;
using Ecomm.Models;
using System.Data.SqlClient;
using System.Linq;

namespace Ecomm.DataAccess.Products
{
    public class ProductProvider : IProductProvider
    {
        private readonly string _connectionString;

        public ProductProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Product[] Get()
        {
            using var connection = new SqlConnection(_connectionString);
            const string query = @"SELECT Id, Name, Description, Type FROM Product";
            return connection.Query<Product>(query)
                .ToArray();
        }
    }
}
