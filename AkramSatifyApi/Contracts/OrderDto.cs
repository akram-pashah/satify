using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Helpers.Enums;

namespace Contracts
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderedOn { get; set; }
        public DateTime? ClosedOn { get; set; }
        public int AddressId { get; set; }
        public int SellerId { get; set; }
        public string SellerName { get; set; }
        public OrderStatus Status { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public int UserId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
