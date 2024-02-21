using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    //public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    internal sealed class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<Account>> GetAllByOwnerIdAsync(Guid ownerId) =>
            await FindByCondition(ac => ac.OwnerId == ownerId).ToListAsync();

        public async Task<Account> GetByIdAsync(Guid accountId) =>
            await FindByCondition(ac => ac.Id == accountId).FirstOrDefaultAsync();

        public void Insert(Account account) => Create(account);

        public void Remove(Account account) => Delete(account);
    }
}
