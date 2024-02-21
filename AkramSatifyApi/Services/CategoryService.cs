using AutoMapper;
using Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Helpers;
using Domain.Models;
using Domain.Repositories;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Services
{
    internal sealed class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CategoryService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<PagedList<CategoryDto>> GetAllAsync(CategoryParameters categoryParameters)
        {
            var categories = await _repositoryManager.CategoryRepository.GetAllAsync(categoryParameters);

            var data = DtoConverter.ConvertToPagedList(categories, category => _mapper.Map<CategoryDto>(category));

            return data;
        }

        public async Task<CategoryWithProductsDto> GetByIdAsync(int categoryId)
        {
            var category = await _repositoryManager.CategoryRepository.GetByIdAsync(categoryId) ?? throw new CategoryNotFoundException(categoryId);

            var categoryDto = _mapper.Map<CategoryWithProductsDto>(category);

            return categoryDto;
        }

        public async Task<CategoryDto> CreateAsync(CategoryForCreationDto categoryForCreationDto)
        {
            var category = _mapper.Map<Category>(categoryForCreationDto);

            try
            {
                _repositoryManager.CategoryRepository.Insert(category);

                await _repositoryManager.UnitOfWork.SaveChangesAsync();

                var filePath = Path.Combine("wwwroot", "images", "categories", category.Id.ToString(), categoryForCreationDto.ImageFile.FileName);

                var directoryPath = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                using var stream = new FileStream(filePath, FileMode.Create);
                await categoryForCreationDto.ImageFile.CopyToAsync(stream);
            }
            catch (Exception ex)
            {

                throw;
            }

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task UpdateAsync(int categoryId, CategoryForUpdateDto categoryForUpdateDto)
        {
            var category = await _repositoryManager.CategoryRepository.GetByIdAsync(categoryId) ?? throw new CategoryNotFoundException(categoryId);

            category.Name = categoryForUpdateDto.Name;
            category.FileName = categoryForUpdateDto.ImageFile.FileName;

            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            var filePath = Path.Combine("wwwroot", "images", "Categories", category.Id.ToString(), categoryForUpdateDto.ImageFile.FileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await categoryForUpdateDto.ImageFile.CopyToAsync(stream);

            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }


        public async Task DeleteAsync(int categoryId)
        {
            var category = await _repositoryManager.CategoryRepository.GetByIdAsync(categoryId) ?? throw new CategoryNotFoundException(categoryId);
            _repositoryManager.CategoryRepository.Remove(category);

            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }
    }
}
