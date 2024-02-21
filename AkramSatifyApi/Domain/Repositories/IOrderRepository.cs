using Domain.Entities;
using Domain.Models;

namespace Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> PlaceOrder(OrderParameters orderParameterss);

        Task<Order> GetOrderById(OrderParameters orderParameters);

        Task UpdateOrder(OrderParameters orderParameters);

        Task<List<Order>> GetOrderByUserId(int userid);

        Task<Stream> GenerateInvoice(int orderId);
    }
}
