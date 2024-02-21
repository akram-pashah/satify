using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountDto>> GetAllByOwnerIdAsync(Guid ownerId);

        Task<AccountDto> GetByIdAsync(Guid ownerId, Guid accountId);

        Task<AccountDto> CreateAsync(Guid ownerId, AccountForCreationDto accountForCreationDto);

        Task DeleteAsync(Guid ownerId, Guid accountId);
    }
}
