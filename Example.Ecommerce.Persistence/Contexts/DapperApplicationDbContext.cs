using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Example.Ecommerce.Persistence.Contexts
{
    public class DapperApplicationDbContext
    {
        private readonly string _connectionString;

        public DapperApplicationDbContext(IConfiguration configuration) =>
            _connectionString = configuration.GetConnectionString("NorthwindConnection")!;

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}