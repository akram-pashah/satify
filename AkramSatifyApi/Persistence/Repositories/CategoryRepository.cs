using Domain.Entities;
using Domain.Helpers;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    internal sealed class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<PagedList<Category>> GetAllAsync(CategoryParameters categoryParameters) => PagedList<Category>.ToPagedList(FindAll(),
                categoryParameters.PageNumber, categoryParameters.PageSize);

        public async Task<Category> GetByIdAsync(int categoryId) => await FindByCondition(c => c.Id == categoryId).Include(c =>c.Products).ThenInclude(p => p.MediaFiles).FirstAsync();

        public void Insert(Category category) => Create(category);

        public void Remove(Category category) => Delete(category);
    }
}
