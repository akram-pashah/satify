using AutoMapper;
using Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Helpers;
using Domain.Models;
using Domain.Repositories;
using Services.Abstractions;

namespace Services
{
    internal sealed class OwnerService : IOwnerService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public OwnerService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<PagedList<OwnerDto>> GetAllAsync(OwnerParameters ownerParameters)
        {
            var owners = await _repositoryManager.OwnerRepository.GetAllAsync(ownerParameters);

            var data = DtoConverter.ConvertToPagedList(owners, owner => _mapper.Map<OwnerDto>(owner));

            return data;
        }

        public async Task<OwnerDto> GetByIdAsync(Guid ownerId)
        {
            var owner = await _repositoryManager.OwnerRepository.GetByIdAsync(ownerId) ?? throw new OwnerNotFoundException(ownerId);
            var ownerDto = _mapper.Map<OwnerDto>(owner);

            return ownerDto;
        }

        public async Task<OwnerDto> CreateAsync(OwnerForCreationDto ownerForCreationDto)
        {
            var owner = _mapper.Map<Owner>(ownerForCreationDto);

            _repositoryManager.OwnerRepository.Insert(owner);

            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            return _mapper.Map<OwnerDto>(owner);
        }

        public async Task UpdateAsync(Guid ownerId, OwnerForUpdateDto ownerForUpdateDto)
        {
            var owner = await _repositoryManager.OwnerRepository.GetByIdAsync(ownerId) ?? throw new OwnerNotFoundException(ownerId);
            owner.Name = ownerForUpdateDto.Name;
            owner.DateOfBirth = ownerForUpdateDto.DateOfBirth;
            owner.Address = ownerForUpdateDto.Address;

            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid ownerId)
        {
            var owner = await _repositoryManager.OwnerRepository.GetByIdAsync(ownerId) ?? throw new OwnerNotFoundException(ownerId);
            _repositoryManager.OwnerRepository.Remove(owner);

            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }
    }
}
