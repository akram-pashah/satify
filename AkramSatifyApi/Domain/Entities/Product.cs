using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductPrice { get; set; }
        public float MaxQuantity { get; set; }
        public float? MinQuantity { get; set; }
        public string? QuantityUnit { get; set; }
        public float Discount { get; set; }
        public string? ProductVariants { get; set; }
        public string? Tags { get; set; }
        public string? CategoryType { get; set; }
        public double AverageRating => CalculateAverageRating();
        public bool IsFeatured { get; set; }
        public bool IsVisible { get; set; }
        public bool IsInStock { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
        public Category Category { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public List<CartItem> CartItems { get; set; }
        public List<MediaFile> MediaFiles { get; set; }
        private double CalculateAverageRating()
        {
            if (Ratings == null || !Ratings.Any())
            {
                return 0;
            }

            return Ratings.Average(r => r.Value);
        }
    }
}
