using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.DTO;
using Dapper;

namespace CoffeeShop.DAO
{
    /// <summary>
    /// Repository for managing information about the tables in the shop.
    /// </summary>
    internal class TableRepository : BaseRepository
    {
        // Retrieves a list of all tables.
        public List<Table> GetAll()
        {
            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();
                string sql = "SELECT * FROM Tables";
                return connection.Query<Table>(sql).ToList();
            }
        }

        // Retrieves a list of all currently free tables.
        public List<Table> GetAllFree()
        {
            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();
                string sql = "SELECT * FROM Tables WHERE Status = 'Free'";
                return connection.Query<Table>(sql).ToList();
            }
        }

        // Updates the status of a table (Free/Occupied).
        public void SetStatus(int tableId, string status)
        {
            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();
                string sql = @"UPDATE Tables
                               SET Status = @Status
                               WHERE Id = @Id";
                connection.Execute(sql, new { Id = tableId, Status = status });
            }
        }
    }
}
