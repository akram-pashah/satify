using Domain;
using Domain.Entities;
using Domain.Helpers;
using Domain.Repositories;
using Persistence;
using Persistence.Repositories;
using Repository;

namespace RepPersistence.Repositoriesository
{
    //public class RepositoryManager : IRepositoryManager
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IOwnerRepository> _lazyOwnerRepository;
        private readonly Lazy<IAccountRepository> _lazyAccountRepository;
        private readonly Lazy<ICategoryRepository> _lazyCategoryRepository;
        private readonly Lazy<IProductRepository> _lazyProductRepository;
        private readonly Lazy<ICartRepository> _lazyCartRepository;
        private readonly Lazy<IOrderRepository> _lazyOrderRepository;
        private readonly Lazy<IUserRepository> _lazyUserRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(RepositoryDbContext dbContext, ISortHelper<Owner> _ownerSortHelder)
        {
            _lazyOwnerRepository = new Lazy<IOwnerRepository>(() => new OwnerRepository(dbContext, _ownerSortHelder));
            _lazyAccountRepository = new Lazy<IAccountRepository>(() => new AccountRepository(dbContext));
            _lazyCategoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(dbContext));
            _lazyProductRepository = new Lazy<IProductRepository>(() => new ProductRepository(dbContext));
            _lazyCartRepository = new Lazy<ICartRepository>(() => new CartRepository(dbContext));
            _lazyUserRepository = new Lazy<IUserRepository>(() => new UserRepository(dbContext));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
            _lazyOrderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(dbContext));
        }

        public IOwnerRepository OwnerRepository => _lazyOwnerRepository.Value;

        public IAccountRepository AccountRepository => _lazyAccountRepository.Value;

        public ICategoryRepository CategoryRepository => _lazyCategoryRepository.Value;

        public IProductRepository ProductRepository => _lazyProductRepository.Value;

        public ICartRepository CartRepository => _lazyCartRepository.Value;

        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;

        public IUserRepository UserRepository => _lazyUserRepository.Value;

        public IOrderRepository OrderRepository => _lazyOrderRepository.Value;
    }
}
