using Contracts;
using Domain.Models;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;

        public CategoryController(IServiceManager serviceManager, ILoggerManager logger)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories([FromQuery] CategoryParameters categoryParameters)
        {
            var categories = await _serviceManager.CategoryService.GetAllAsync(categoryParameters);

            var metadata = new
            {
                categories.TotalCount,
                categories.PageSize,
                categories.CurrentPage,
                categories.TotalPages,
                categories.HasNext,
                categories.HasPrevious,
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

            _logger.LogInfo($"Returned {categories.TotalCount} categories from database.");

            return Ok(categories);
        }

        [HttpGet("{categoryId:int}")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            var categoryDto = await _serviceManager.CategoryService.GetByIdAsync(categoryId);

            return Ok(categoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromForm] CategoryForCreationDto categoryForCreationDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoryDto = await _serviceManager.CategoryService.CreateAsync(categoryForCreationDto);

            return CreatedAtAction(nameof(GetCategoryById), new { categoryId = categoryDto.Id}, categoryDto);
        }

        [HttpPut("{categoryId:int}")]
        public async Task<IActionResult> UpdateCategory(int categoryId, [FromForm]CategoryForUpdateDto categoryForUpdateDto)
        {
            await _serviceManager.CategoryService.UpdateAsync(categoryId, categoryForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{categoryId:int}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            await _serviceManager.CategoryService.DeleteAsync(categoryId);

            return NoContent();
        }
    }
}
