using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? SellerId { get; set; }
        public Seller? Seller { get; set; }
    }
}
