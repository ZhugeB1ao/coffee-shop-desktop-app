using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DTO
{
    internal class BillInfo
    {
        public int Id { get; set; }
        public int IdBill { get; set; }
        public int IdProduct { get; set; }
        public int Count { get; set; }
    }
}
