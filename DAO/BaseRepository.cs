using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DAO
{
    /// <summary>
    /// Base class for all repositories, managing connection strings and providing SqlConnection objects.
    /// </summary>
    internal abstract class BaseRepository
    {
        private readonly string _connectionString;

        public BaseRepository()
        {
            // Retrieve the connection string from the App.config file.
            _connectionString = ConfigurationManager.ConnectionStrings["QLQuanCafe"].ConnectionString;
        }

        /// <summary>
        /// Creates a new connection to the SQL Server database.
        /// </summary>
        /// <returns>A SqlConnection object.</returns>
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
