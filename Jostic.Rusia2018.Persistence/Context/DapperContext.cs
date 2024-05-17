using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Jostic.Rusia2018.Persistence.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("NorthwindConnection")!;
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

    }
}