using Contracts;
using Domain.Helpers;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IProductService
    {
        Task<PagedList<ProductDto>> GetAllAsync(ProductParameters productParameters);

        Task<ProductDto> GetByIdAsync(int productId);

        Task<ProductDto> CreateAsync(ProductForCreationDto productForCreationDto);

        Task UpdateAsync(int productId, ProductForUpdateDto productForUpdateDto);

        Task DeleteAsync(int productId);
    }
}
