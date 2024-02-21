using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Seller
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public List<Address> Addresses { get; set; }
        public string? PayPalId { get; set; }
        public string? TaxIdentificationNumber { get; set; }
        public string? SellerType { get; set; }
        public string? OfferedServices { get; set; }
        public string? Description { get; set; }
        public string? Facebook { get; set; }
        public string? Twitter { get; set; }
        public string? Instagram { get; set; }
        public string? YouTube { get; set; }
        public string? Website { get; set; }
        public string? ProfileUrl { get; set; }
        public List<Product> Products { get; set; }
    }
}
