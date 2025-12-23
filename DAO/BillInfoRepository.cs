using CoffeeShop.DTO;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CoffeeShop.DAO
{
    /// <summary>
    /// Repository for managing bill details (items in a bill).
    /// </summary>
    internal class BillInfoRepository : BaseRepository
    {
        // Retrieves the list of bill details by bill ID.
        public List<BillInfo> GetByBillId(int billId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                string sql = "SELECT * FROM BillInfo WHERE IdBill = @IdBill";
                return conn.Query<BillInfo>(sql, new { IdBill = billId }).ToList();
            }
        }

        // Finds a specific product in a bill (used to check if an item has already been ordered).
        public BillInfo GetByBillIdAndProductId(int billId, int productId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                string sql = "SELECT * FROM BillInfo WHERE IdBill = @IdBill AND IdProduct = @IdProduct";
                return conn.QueryFirstOrDefault<BillInfo>(sql, new { IdBill = billId, IdProduct = productId });
            }
        }

        // Adds a new item to the current bill.
        public void Add(BillInfo billInfo)
        {
            using (SqlConnection conn = CreateConnection())
            {
                string sql = "INSERT INTO BillInfo (IdBill, IdProduct, Count) VALUES (@IdBill, @IdProduct, @Count)";
                conn.Execute(sql, billInfo);
            }
        }

        // Updates the quantity of an ordered item.
        public void Update(BillInfo billInfo)
        {
            using (SqlConnection conn = CreateConnection())
            {
                string sql = "UPDATE BillInfo SET Count = @Count WHERE Id = @Id";
                conn.Execute(sql, billInfo);
            }
        }

        // Deletes an item from the bill.
        public void Delete(int id)
        {
            using (SqlConnection conn = CreateConnection())
            {
                string sql = "DELETE FROM BillInfo WHERE Id = @Id";
                conn.Execute(sql, new { Id = id });
            }
        }
    }
}

