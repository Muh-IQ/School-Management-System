using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Infrastructure.Presistent
{
    internal class ConnectionProvider
    {
        private readonly string _connectionString;

        // Constructor reads the connection string from an environment variable
        public ConnectionProvider()
        {
            _connectionString = Environment.GetEnvironmentVariable("SCHOOL_MODULE____DB_CONNECTION")
                ?? throw new InvalidOperationException("Database connection string is not set in environment variables.");
        }

        public string GetConnectionString() => _connectionString;
    }
}
