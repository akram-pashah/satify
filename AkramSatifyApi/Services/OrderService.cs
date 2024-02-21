using AutoMapper;
using Contracts;
using Domain.Models;
using Domain.Repositories;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class OrderService : IOrderService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public OrderService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public Task<Stream> GenerateInvoice(int orderId)
        {
            return _repositoryManager.OrderRepository.GenerateInvoice(orderId);
        }

        public Task<OrderDto> GetOrderById(OrderParameters orderParameters)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderDto>> GetOrderByUserId(int userid)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto> PlaceOrder(OrderParameters orderParameterss)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrder(OrderParameters orderParameters)
        {
            throw new NotImplementedException();
        }
    }
}
