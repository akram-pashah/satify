
namespace Domain.Repositories
{
    public interface IRepositoryManager
    {
        IOwnerRepository OwnerRepository { get; }

        IAccountRepository AccountRepository { get; }

        IUserRepository UserRepository { get; }

        ICategoryRepository CategoryRepository { get; }

        IProductRepository ProductRepository { get; }

        ICartRepository CartRepository { get; }

        IOrderRepository OrderRepository { get; }

        IUnitOfWork UnitOfWork { get; }
    }
}
