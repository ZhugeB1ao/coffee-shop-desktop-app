using CoffeeShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
namespace CoffeeShop.DAO
{
    /// <summary>
    /// Repository for managing data operations for the Bill table.
    /// </summary>
    internal class BillRepository : BaseRepository
    {
        // Retrieves bill information by its ID.
        public Bill GetById(int billId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                string sql = "SELECT * FROM Bill WHERE Id = @Id";
                return conn.QueryFirstOrDefault<Bill>(sql, new { Id = billId });
            }
        }

        // Finds the unpaid bill for a specific table.
        public Bill GetUnpaidBillByTableId(int tableId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                string sql = "SELECT * FROM Bill WHERE IdTable = @IdTable AND Status = 0";
                return conn.QueryFirstOrDefault<Bill>(sql, new { IdTable = tableId });
            }
        }

        // Creates a new bill for a table when ordering begins.
        public int CreateBill(int tableId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                string sql = "INSERT INTO Bill (DateCheckIn, IdTable, Status) VALUES (GETDATE(), @IdTable, 0); SELECT CAST(SCOPE_IDENTITY() AS INT);";
                return conn.QuerySingle<int>(sql, new { IdTable = tableId });
            }
        }

        // Updates bill information.
        public void Update(Bill bill)
        {
            using (SqlConnection conn = CreateConnection())
            {
                string sql = @"UPDATE Bill 
                               SET DateCheckIn = @DateCheckIn, 
                                   DateCheckOut = @DateCheckOut, 
                                   IdTable = @IdTable, 
                                   Status = @Status 
                               WHERE Id = @Id";
                conn.Execute(sql, bill);
            }
        }

        // Processes bill payment.
        public void PayBill(int billId, float price)
        {
            using (SqlConnection conn = CreateConnection())
            {
                string sql = @"UPDATE Bill SET Status = 1, DateCheckOut = GETDATE(), Price = @Price WHERE Id = @Id";
                conn.Execute(sql, new { Id = billId, Price = price });
            }
        }

        // Retrieves a list of paid bills within a specific date range (for statistics).
        public IEnumerable<dynamic> GetBillListByDate(DateTime from, DateTime to)
        {
            using (SqlConnection conn = CreateConnection())
            {
                // Join with the Tables table to retrieve the table name for better display.
                string sql = @"SELECT t.Name as TableName, b.Price as TotalPrice, b.DateCheckIn as CheckIn, b.DateCheckOut as CheckOut
                               FROM Bill b 
                               JOIN Tables t ON b.IdTable = t.Id 
                               WHERE b.Status = 1 AND b.DateCheckOut >= @From AND b.DateCheckOut <= @To";
                return conn.Query(sql, new { From = from, To = to }).ToList();
            }
        }
    }
}
