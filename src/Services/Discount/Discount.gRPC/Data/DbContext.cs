using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Discount.API.Data
{
    public class DbContext : IDbContext
    {
        private readonly IConfiguration _configuration;
        private IDbConnection _connection;

        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection DbConnection
        {
            get
            {
                _connection =
                    new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
                _connection.Open();
                return _connection;
            }
        }
    }
}