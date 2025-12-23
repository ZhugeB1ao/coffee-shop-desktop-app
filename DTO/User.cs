using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DTO
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? DisplayName { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public string? CitizenId { get; set; }
        public DateTime? Birthday { get; set; }
        public string? PhoneNumber { get; set; }
        public byte[]? Picture { get; set; }
    }
}
