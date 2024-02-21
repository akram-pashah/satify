using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UserService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await _repositoryManager.UserRepository.GetAllAsync();

            return users;
        }

        public async Task<User> GetByIdAsync(int userId)
        {
            var user = await _repositoryManager.UserRepository.GetByIdAsync(userId);

            return user;
        }

        public void Insert(User user)
        {
            _repositoryManager.UserRepository.Insert(user);
        }

        public void Remove(User user)
        {
            _repositoryManager.UserRepository.Remove(user);
        }
    }
}
