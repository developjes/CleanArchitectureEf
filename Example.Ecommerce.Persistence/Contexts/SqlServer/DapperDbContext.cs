using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Example.Ecommerce.Persistence.Contexts.SqlServer
{
    public class DapperDbContext
    {
        private readonly string _connectionString;

        public DapperDbContext(IConfiguration configuration) =>
            _connectionString = configuration.GetConnectionString("NorthwindConnection")!;

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}