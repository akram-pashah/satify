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
    public interface IProductRepository
    {
        Task<PagedList<Product>> GetAllAsync(ProductParameters productParameters);

        Task<Product> GetByIdAsync(int productId);

        void Insert(Product product);

        void Modify(Product product);

        void Remove(Product product);
    }
}
