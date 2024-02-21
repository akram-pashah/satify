using Domain.Entities;
using Domain.Helpers;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<PagedList<Category>> GetAllAsync(CategoryParameters categoryParameters);

        Task<Category> GetByIdAsync(int categoryId);

        void Insert(Category category);

        void Remove(Category category);
    }
}
