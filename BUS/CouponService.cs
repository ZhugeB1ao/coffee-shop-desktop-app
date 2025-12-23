using CoffeeShop.DAO;
using CoffeeShop.DTO;
using System.Collections.Generic;

namespace CoffeeShop.BUS
{
    /// <summary>
    /// Service class for handling discount coupon logic.
    /// </summary>
    internal class CouponService
    {
        private CouponRepository repo;

        public CouponService()
        {
            repo = new CouponRepository();
        }

        // Retrieves all discount coupons.
        public List<Coupon> GetAll() => repo.GetAll();

        // Finds a coupon by its code.
        public Coupon GetByCode(string code) => repo.GetByCode(code);

        // Checks if a coupon code is valid.
        public bool IsValidCode(string code) => repo.GetByCode(code) != null;

        // Retrieves the discount value from a coupon code.
        public decimal GetDiscountValue(string code)
        {
            var coupon = repo.GetByCode(code);
            return coupon != null ? coupon.DiscountValue : 0;
        }

        // Adds a new discount coupon.
        public void Add(Coupon coupon) => repo.Add(coupon);

        // Updates discount coupon information.
        public void Update(Coupon coupon) => repo.Update(coupon);

        // Deletes a discount coupon.
        public void Delete(int id) => repo.Delete(id);
    }
}
