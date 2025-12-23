using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DTO
{
    internal class Bill
    {
        public int Id { get; set; }
        public DateTime? DateCheckIn { get; set; }
        public DateTime? DateCheckOut { get; set; }
        public int IdTable { get; set; }
        public int Status { get; set; } = 0;
        public float Price { get; set; }
    }
}
