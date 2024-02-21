namespace Domain.Models
{
    public class OrderParameters : QueryStringParameters
    {
        public int? OrderId { get; set; }
        public int? OrderStatus { get; set; }
        public int? PaymentStatus { get; set; }
        public int? SellerId { get; set; }
        public int? DeliveryBoyId { get; set; }
        public int AddressId { get; set; }
        public int UserId { get; set; }
    }
}
