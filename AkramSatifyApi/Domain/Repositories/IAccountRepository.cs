using Domain.Entities;

namespace Domain.Repositories
{
    //public interface IAccountRepository : IRepositoryBase<Account>
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllByOwnerIdAsync(Guid ownerId);

        Task<Account> GetByIdAsync(Guid accountId);

        void Insert(Account account);

        void Remove(Account account);
    }
}
