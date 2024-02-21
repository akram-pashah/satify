using AutoMapper;
using Contracts;
using Domain.Entities;
using Domain.Models;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System.Text.Json;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/owners")]
    public class OwnersController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;

        public OwnersController(IServiceManager serviceManager, ILoggerManager logger)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetOwners([FromQuery] OwnerParameters ownerParameters)
        {
            var owners = await _serviceManager.OwnerService.GetAllAsync(ownerParameters);

            var metadata = new
            {
                owners.TotalCount,
                owners.PageSize,
                owners.CurrentPage,
                owners.TotalPages,
                owners.HasNext,
                owners.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

            _logger.LogInfo($"Returned {owners.TotalCount} owners from database.");

            return Ok(owners);
        }

        [HttpGet("{ownerId:guid}")]
        public async Task<IActionResult> GetOwnerById(Guid ownerId)
        {
            var ownerDto = await _serviceManager.OwnerService.GetByIdAsync(ownerId);

            return Ok(ownerDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwner([FromBody] OwnerForCreationDto ownerForCreationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ownerDto = await _serviceManager.OwnerService.CreateAsync(ownerForCreationDto);

            return CreatedAtAction(nameof(GetOwnerById), new { ownerId = ownerDto.Id }, ownerDto);
        }

        [HttpPut("{ownerId:guid}")]
        public async Task<IActionResult> UpdateOwner(Guid ownerId, [FromBody] OwnerForUpdateDto ownerForUpdateDto)
        {
            await _serviceManager.OwnerService.UpdateAsync(ownerId, ownerForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{ownerId:guid}")]
        public async Task<IActionResult> DeleteOwner(Guid ownerId)
        {
            await _serviceManager.OwnerService.DeleteAsync(ownerId);

            return NoContent();
        }
    }
}
