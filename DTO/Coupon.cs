using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DTO
{
    internal class Coupon
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal DiscountValue { get; set; }
        public int Enable { get; set; } = 1;
    }
}
