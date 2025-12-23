using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DTO
{
    internal class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Enable { get; set; } = 1;
    }
}
