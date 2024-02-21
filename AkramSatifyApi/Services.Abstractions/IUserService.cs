using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();

        Task<User> GetByIdAsync(int userId);

        void Insert(User user);

        void Remove(User user);
    }
}
