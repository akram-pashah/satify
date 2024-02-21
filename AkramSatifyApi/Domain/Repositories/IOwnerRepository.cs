using Domain.Entities;
using Domain.Helpers;
using Domain.Models;

namespace Domain.Repositories
{
    //public interface IOwnerRepository : IRepositoryBase<Owner>
    public interface IOwnerRepository
    {
        Task<PagedList<Owner>> GetAllAsync(OwnerParameters ownerParameters);

        Task<Owner> GetByIdAsync(Guid ownerId);

        void Insert(Owner owner);

        void Remove(Owner owner);
    }
}
