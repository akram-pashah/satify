using Domain;
using Domain.Entities;
using Domain.Helpers;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Repositories;

namespace Repository
{
    //public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    internal sealed class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        private ISortHelper<Owner> _sortHelper;
        public OwnerRepository(RepositoryDbContext dbContext, ISortHelper<Owner> sortHelper) : base(dbContext)
        {
            _sortHelper = sortHelper;
        }

        public async Task<PagedList<Owner>> GetAllAsync(OwnerParameters ownerParameters)
        {
            var owners = FindByCondition(o => o.DateOfBirth.Year >= ownerParameters.MinYearOfBirth && o.DateOfBirth.Year <= ownerParameters.MaxYearOfBirth);

            if (!string.IsNullOrEmpty(ownerParameters.Name))
            {
                SearchByName(ref owners, ownerParameters.Name);
            }

            var sortedOwners = _sortHelper.ApplySort(owners, ownerParameters.OrderBy);

            return PagedList<Owner>.ToPagedList(sortedOwners.Include(o => o.Accounts).OrderBy(ow => ow.Name),
                ownerParameters.PageNumber, ownerParameters.PageSize);
        }

        private static void SearchByName(ref IQueryable<Owner> owners, string ownerName)
        {
            if (!owners.Any() || string.IsNullOrWhiteSpace(ownerName))
                return;

            owners = owners.Where(o => o.Name.ToLower().Contains(ownerName.Trim().ToLower()));
        }

        public async Task<Owner> GetByIdAsync(Guid ownerId) =>
            await FindByCondition(ow => ow.Id == ownerId).Include(x => x.Accounts).FirstOrDefaultAsync(x => x.Id == ownerId);

        public void Insert(Owner owner) => Create(owner);

        public void Remove(Owner owner) => Delete(owner);
    }
}
