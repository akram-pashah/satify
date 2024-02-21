using static Domain.Helpers.Enums;

namespace Domain.Utilities
{
    public static class OrderStatusExtensions
    {
        public static int ToInt(this OrderStatus status)
        {
            return (int)status;
        }

        public static OrderStatus ToOrderStatus(this int status)
        {
            return (OrderStatus)status;
        }
    }
}
