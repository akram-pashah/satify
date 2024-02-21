namespace Domain.Entities
{
    public class UserOffer
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int OfferId { get; set; }
        public Offer Offer { get; set; }
    }
}
