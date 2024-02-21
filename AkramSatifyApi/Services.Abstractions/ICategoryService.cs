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
    public interface ICategoryService
    {
        Task<PagedList<CategoryDto>> GetAllAsync(CategoryParameters categoryParameters);

        Task<CategoryWithProductsDto> GetByIdAsync(int categoryId);

        Task<CategoryDto> CreateAsync(CategoryForCreationDto categoryForCreationDto);

        Task UpdateAsync(int categoryId, CategoryForUpdateDto categoryForUpdateDto);

        Task DeleteAsync(int categoryId);
    }
}
