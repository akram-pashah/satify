using Domain.Entities;
using Domain.Repositories;
using Domain.Utilities;
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
    [Route("api/user/{user:int}/order")]
    public class OrderController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;

        public OrderController(IServiceManager serviceManager, ILoggerManager logger)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GenerateInvoice(int orderId)
        {
            return File(await _serviceManager.OrderService.GenerateInvoice(orderId), "application/pdf", $"Invoice-{orderId}.pdf");
        }
    }
}
