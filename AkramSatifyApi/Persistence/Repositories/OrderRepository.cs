using Domain.Entities;
using Domain.Models;
using Domain.Repositories;
using Domain.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private readonly RepositoryDbContext _repositoryContext;
        public OrderRepository(RepositoryDbContext dbContext) : base(dbContext)
        {
            _repositoryContext = dbContext;
        }

        public async Task<Stream> GenerateInvoice(int orderId)
        {
            PdfInvoiceGenerator generator = new PdfInvoiceGenerator();

            return generator.GenerateInvoice(await FindByCondition(o => o.Id == orderId).FirstAsync());
        }

        public async Task<Order> GetOrderById(OrderParameters orderParameters)
        {
            return await FindByCondition(o => o.Id == orderParameters.OrderId).Include(o => o.OrderItems).Include(o => o.Seller).Include(o => o.DeliveryBoy).Include(o => o.User).FirstAsync();
        }

        public async Task<List<Order>> GetOrderByUserId(int userid)
        {
            return await FindByCondition(o => o.UserId == userid).Include(o => o.OrderItems).Include(o => o.Seller).Include(o => o.DeliveryBoy).Include(o => o.User).ToListAsync();
        }

        public async Task<Order> PlaceOrder(OrderParameters orderParameterss)
        {
            var cart = await _repositoryContext.Carts.Where(c => c.UserId == orderParameterss.UserId).Include(c => c.CartItems).FirstAsync();

            List<OrderItem> orderItems = new();

            foreach (var cartItem in cart.CartItems)
            {
                orderItems.Add(new OrderItem()
                {
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                });
            }
            var order = new Order()
            {
                AddressId = orderParameterss.AddressId,
                UserId = orderParameterss.UserId,
                OrderedOn = DateTime.Now,
                Status = Domain.Helpers.Enums.OrderStatus.Pending,
                PaymentStatus = Domain.Helpers.Enums.PaymentStatus.Pending,
                OrderItems = orderItems
            };
            _repositoryContext.Add(order);

            await _repositoryContext.SaveChangesAsync();

            return order;
        }

        public async Task UpdateOrder(OrderParameters orderParameters)
        {
            var order = await FindByCondition(o => o.Id == orderParameters.OrderId).FirstAsync();

            if(orderParameters.SellerId != null)
            {
                order.SellerId = (int)orderParameters.SellerId;
            }

            if (orderParameters.DeliveryBoyId != null)
            {
                order.DeliveryBoyId = (int)orderParameters.DeliveryBoyId;
            }

            if (orderParameters.OrderStatus != null)
            {
                order.Status = (Domain.Helpers.Enums.OrderStatus)(int)orderParameters.OrderStatus;
            }

            if (orderParameters.PaymentStatus != null)
            {
                order.PaymentStatus = (Domain.Helpers.Enums.PaymentStatus)(int)orderParameters.PaymentStatus;
            }

            Update(order);
        }
    }
}
