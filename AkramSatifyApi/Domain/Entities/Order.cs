using static Domain.Helpers.Enums;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderedOn { get; set; }
        public DateTime? ClosedOn { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
        public OrderStatus Status { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public decimal TotalAmount => CalculateTotalAmount();
        public int UserId { get; set; }
        public User User { get; set; }
        public int DeliveryBoyId { get; set; }
        public DeliveryBoy DeliveryBoy { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public List<UserOffer> UserOffers { get; set; }
        private decimal CalculateTotalAmount()
        {
            if (OrderItems == null || OrderItems.Count == 0)
            {
                return 0;
            }

            decimal total = 0;
            foreach (var orderItem in OrderItems)
            {
                decimal discountedPrice = decimal.Parse(orderItem.Product.ProductPrice) -
                                          (decimal.Parse(orderItem.Product.ProductPrice) * (decimal)orderItem.Product.Discount / 100);

                total += discountedPrice * orderItem.Quantity;
            }

            return total;
        }
    }
}
