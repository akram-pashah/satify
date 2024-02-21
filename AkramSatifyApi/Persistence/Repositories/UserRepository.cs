using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<User>> GetAllAsync() => await FindAll().ToListAsync();
        public async Task<User> GetByIdAsync(int userId) => await FindByCondition(u => u.Id == userId).FirstOrDefaultAsync();

        public void Insert(User user) => Create(user);

        public void Remove(User user) => Delete(user);
    }
}
