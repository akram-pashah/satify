using Contracts;
using Domain.Helpers;
using Domain.Models;

namespace Services.Abstractions
{
    public interface IOwnerService
    {
        Task<PagedList<OwnerDto>> GetAllAsync(OwnerParameters ownerParameters);

        Task<OwnerDto> GetByIdAsync(Guid ownerId);

        Task<OwnerDto> CreateAsync(OwnerForCreationDto ownerForCreationDto);

        Task UpdateAsync(Guid ownerId, OwnerForUpdateDto ownerForUpdateDto);

        Task DeleteAsync(Guid ownerId);
    }
}
