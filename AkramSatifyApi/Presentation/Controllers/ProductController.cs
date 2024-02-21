using Contracts;
using Domain.Models;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/category/{category:int}/products")]
    public class ProductController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;

        public ProductController(IServiceManager serviceManager, ILoggerManager logger)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductParameters productParameters)
        {
            var productsDto = await _serviceManager.ProductService.GetAllAsync(productParameters);

            return Ok(productsDto);
        }

        [HttpGet("{productId:int}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var productDto = await _serviceManager.ProductService.GetByIdAsync(productId);

            return Ok(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm]ProductForCreationDto productForCreationDto)
        {
            var response = await _serviceManager.ProductService.CreateAsync(productForCreationDto);

            return Ok();
        }

        [HttpDelete("{productId:int}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            await _serviceManager.ProductService.DeleteAsync(productId);

            return NoContent();
        }
    }
}
