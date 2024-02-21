using Domain.Entities;
using Domain.Helpers;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<PagedList<Product>> GetAllAsync(ProductParameters productParameters)
        {
            if(productParameters.CategoryId is null || productParameters.CategoryId == 0)
            {
                return PagedList<Product>.ToPagedList(FindAll().Include(p => p.MediaFiles),
                  productParameters.PageNumber, productParameters.PageSize);
            } else
            {
                return PagedList<Product>.ToPagedList(FindByCondition(p => p.CategoryId == productParameters.CategoryId).Include(p => p.MediaFiles).AsQueryable(),
                productParameters.PageNumber, productParameters.PageSize);
            }
        }

        public async Task<Product> GetByIdAsync(int productId) => await FindByCondition(p => p.Id == productId).Include(p => p.Seller).Include(p => p.Category).Include(p => p.MediaFiles).Include(p => p.Comments).Include(p => p.Ratings).FirstAsync();

        public void Insert(Product product) => Create(product);

        public void Modify(Product product) => Update(product);

        public void Remove(Product product) => Delete(product);
    }
}
