using Contracts;
using Domain.Entities;
using Domain.Models;

namespace Services.Abstractions
{
    public interface IOrderService
    {
        Task<OrderDto> PlaceOrder(OrderParameters orderParameterss);

        Task<OrderDto> GetOrderById(OrderParameters orderParameters);

        Task UpdateOrder(OrderParameters orderParameters);

        Task<List<OrderDto>> GetOrderByUserId(int userid);

        Task<Stream> GenerateInvoice(int orderId);
    }
}
