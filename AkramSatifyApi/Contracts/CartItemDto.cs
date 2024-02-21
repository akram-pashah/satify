using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductFileName { get; set; }
        public string? ProductPrice { get; set; }
        public float? MaxQuantity { get; set; }
        public float? MinQuantity { get; set; }
        public string? QuantityUnit { get; set; }
        public float? Discount { get; set; }
        public float? FinalPrice { get; set; }
        public int Quantity { get; set; }
    }
}
