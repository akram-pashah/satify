using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string ProductPrice { get; set; }
        public float MaxQuantity { get; set; }
        public float? MinQuantity { get; set; }
        public string QuantityUnit { get; set; }
        public float Discount { get; set; }
        public string ProductVariants { get; set; }
        public string Tags { get; set; }
        public string CategoryType { get; set; }
        public int Rating { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsVisible { get; set; }
        public bool IsInStock { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int SellerId { get; set; }
        public List<MediaFileForRetrievalDto> MediaFiles { get; set; } = new();
    }
}
