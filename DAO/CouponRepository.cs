using CoffeeShop.DTO;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CoffeeShop.DAO
{
    /// <summary>
    /// Repository for managing discount coupons.
    /// </summary>
    internal class CouponRepository : BaseRepository
    {
        // Retrieves all active discount coupons.
        public List<Coupon> GetAll()
        {
            using (SqlConnection connection = CreateConnection())
            {
                string sql = "SELECT * FROM Coupons WHERE Enable = 1";
                return connection.Query<Coupon>(sql).ToList();
            }
        }

        // Finds coupon information by its code.
        public Coupon GetByCode(string code)
        {
            using (SqlConnection connection = CreateConnection())
            {
                string sql = "SELECT * FROM Coupons WHERE Code = @code AND Enable = 1";
                return connection.QueryFirstOrDefault<Coupon>(sql, new { code });
            }
        }

        // Adds a new discount coupon.
        public void Add(Coupon coupon)
        {
            using (SqlConnection connection = CreateConnection())
            {
                string sql = @"INSERT INTO Coupons (Code, DiscountValue, Enable)
                               VALUES (@Code, @DiscountValue, 1)";
                connection.Execute(sql, coupon);
            }
        }

        // Updates discount coupon information.
        public void Update(Coupon coupon)
        {
            using (SqlConnection connection = CreateConnection())
            {
                string sql = @"UPDATE Coupons
                               SET Code = @Code,
                                   DiscountValue = @DiscountValue
                               WHERE Id = @Id";
                connection.Execute(sql, coupon);
            }
        }

        // Deactivates a discount coupon (soft delete).
        public void Delete(int id)
        {
            using (SqlConnection connection = CreateConnection())
            {
                string sql = "UPDATE Coupons SET Enable = 0 WHERE Id = @id";
                connection.Execute(sql, new { id });
            }
        }
    }
}
