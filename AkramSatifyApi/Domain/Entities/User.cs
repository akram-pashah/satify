using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? MobileNumber { get; set; }
        public List<Address> Addresses { get; set; } = new();
        public string? EmailAddress { get; set; }
        public float Wallet { get; set; }
        public string? UserSid { get; set; }
        public int? SubscriptionId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public List<Order> Orders { get; set; }
        public Cart Cart { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Rating> Ratings { get; set; }
        public Subscription Subscription { get; set; }
        public List<UserOffer> UserOffers { get; set; }
    }
}
