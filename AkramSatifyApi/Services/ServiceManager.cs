using AutoMapper;
using Domain.Repositories;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IOwnerService> _lazyOwnerService;
        private readonly Lazy<IAccountService> _lazyAccountService;
        private readonly Lazy<ICategoryService> _lazyCategoryService;
        private readonly Lazy<IProductService> _lazyProductService;
        private readonly Lazy<IUserService> _lazyUserService;
        private readonly Lazy<ICartService> _lazyCartService;
        private readonly Lazy<IOrderService> _lazyOrderService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _lazyOwnerService = new Lazy<IOwnerService>(() => new OwnerService(repositoryManager, mapper));
            _lazyAccountService = new Lazy<IAccountService>(() => new AccountService(repositoryManager, mapper));
            _lazyCategoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager, mapper));
            _lazyProductService = new Lazy<IProductService>(() => new ProductService(repositoryManager, mapper));
            _lazyUserService = new Lazy<IUserService>(() => new UserService(repositoryManager, mapper));
            _lazyCartService = new Lazy<ICartService>(() => new CartService(repositoryManager,mapper));
            _lazyOrderService = new Lazy<IOrderService>(() => new OrderService(repositoryManager, mapper));
        }

        public IOwnerService OwnerService => _lazyOwnerService.Value;

        public IAccountService AccountService => _lazyAccountService.Value;

        public ICategoryService CategoryService => _lazyCategoryService.Value;

        public IProductService ProductService => _lazyProductService.Value;

        public IUserService UserService => _lazyUserService.Value;

        public ICartService CartService => _lazyCartService.Value;

        public IOrderService OrderService => _lazyOrderService.Value;
    }
}
