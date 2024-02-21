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
    internal sealed class ProductService : IProductService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<PagedList<ProductDto>> GetAllAsync(ProductParameters productParameters)
        {
            var products = await _repositoryManager.ProductRepository.GetAllAsync(productParameters);

            var data = DtoConverter.ConvertToPagedList(products, product => _mapper.Map<ProductDto>(product));

            return data;
        }

        public async Task<ProductDto> GetByIdAsync(int productId)
        {
            var product = await _repositoryManager.ProductRepository.GetByIdAsync(productId) ?? throw new ProductNotFoundException(productId);

            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        public async Task<ProductDto> CreateAsync(ProductForCreationDto productForCreationDto)
        {
            var product = _mapper.Map<Product>(productForCreationDto);

            product.CreatedDate = DateTime.Now;

            _repositoryManager.ProductRepository.Insert(product);

            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            if(productForCreationDto != null && productForCreationDto.Images.Count > 0)
            {
                List<MediaFile> mediaFiles = new();
                foreach (var image in productForCreationDto.Images)
                {
                    try
                    {
                        var filePath = Path.Combine("wwwroot", "images", "products", product.Id.ToString(), image.FileName);

                        var directoryPath = Path.GetDirectoryName(filePath);
                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }

                        using var stream = new FileStream(filePath, FileMode.Create);
                        await image.CopyToAsync(stream);

                        mediaFiles.Add(new MediaFile()
                        {
                            FileName = image.FileName,
                            FileType = image.ContentType,
                            ProductId = product.Id,
                        });
                    }
                    catch (Exception ex)
                    {

                    }
                }

                product.MediaFiles = mediaFiles;

                _repositoryManager.ProductRepository.Modify(product);

                await _repositoryManager.UnitOfWork.SaveChangesAsync();
            }

            return _mapper.Map<ProductDto>(product);
        }

        public async Task UpdateAsync(int productId, ProductForUpdateDto productForUpdateDto)
        {
            var product = await _repositoryManager.ProductRepository.GetByIdAsync(productId) ?? throw new ProductNotFoundException(productId);

            // to-do: image save logic should write here


            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int productId)
        {
            var product = await _repositoryManager.ProductRepository.GetByIdAsync(productId) ?? throw new ProductNotFoundException(productId);
             _repositoryManager.ProductRepository.Remove(product);

            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }
    }
}
