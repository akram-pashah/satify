using AutoMapper;
using Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class AccountService : IAccountService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public AccountService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AccountDto>> GetAllByOwnerIdAsync(Guid ownerId)
        {
            var accounts = await _repositoryManager.AccountRepository.GetAllByOwnerIdAsync(ownerId);

            var accountsDto = _mapper.Map<IEnumerable<AccountDto>>(accounts);

            return accountsDto;
        }

        public async Task<AccountDto> GetByIdAsync(Guid ownerId, Guid accountId)
        {
            var owner = await _repositoryManager.OwnerRepository.GetByIdAsync(ownerId);

            if (owner is null)
            {
                throw new OwnerNotFoundException(ownerId);
            }

            var account = await _repositoryManager.AccountRepository.GetByIdAsync(accountId);

            if (account is null)
            {
                throw new AccountNotFoundException(accountId);
            }

            if (account.OwnerId != owner.Id)
            {
                throw new AccountDoesNotBelongToOwnerException(owner.Id, account.Id);
            }

            var accountDto = _mapper.Map<AccountDto>(account);

            return accountDto;
        }

        public async Task<AccountDto> CreateAsync(Guid ownerId, AccountForCreationDto accountForCreationDto)
        {
            var owner = await _repositoryManager.OwnerRepository.GetByIdAsync(ownerId);

            if (owner is null)
            {
                throw new OwnerNotFoundException(ownerId);
            }

            var account = _mapper.Map<Account>(accountForCreationDto);

            account.OwnerId = owner.Id;

            _repositoryManager.AccountRepository.Insert(account);

            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            return _mapper.Map<AccountDto>(account);
        }

        public async Task DeleteAsync(Guid ownerId, Guid accountId)
        {
            var owner = await _repositoryManager.OwnerRepository.GetByIdAsync(ownerId);

            if (owner is null)
            {
                throw new OwnerNotFoundException(ownerId);
            }

            var account = await _repositoryManager.AccountRepository.GetByIdAsync(accountId);

            if (account is null)
            {
                throw new AccountNotFoundException(accountId);
            }

            if (account.OwnerId != owner.Id)
            {
                throw new AccountDoesNotBelongToOwnerException(owner.Id, account.Id);
            }

            _repositoryManager.AccountRepository.Remove(account);

            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }
    }
}
