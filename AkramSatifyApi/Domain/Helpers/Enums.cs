namespace Domain.Helpers
{
    public static class Enums
    {
        public enum OrderStatus
        {
            Pending = 0,
            Processing = 1,
            Shipped = 2,
            Delivered = 3,
            Cancelled = 4
        }

        public enum PaymentStatus
        {
            Pending = 1,
            Processing = 2,
            Completed = 3,
            Failed = 4,
            Refunded = 5
        }
    }
}
