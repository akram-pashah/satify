using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class ProductForCreationDto
    {
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public float MaxQuantity { get; set; }
        public float? MinQuantity { get; set; }
        public string QuantityUnit { get; set; }
        public float Discount { get; set; }
        public string ProductVariants { get; set; }
        public string Tags { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsVisible { get; set; }
        public bool IsInStock { get; set; }
        public int SellerId { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
