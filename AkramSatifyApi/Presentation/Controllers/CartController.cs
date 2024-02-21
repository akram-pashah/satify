using Contracts;
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
    [Route("api/user/{user:int}/cart")]
    public class CartController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;

        public CartController(IServiceManager serviceManager, ILoggerManager logger)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetCart(int userid)
        {
            var cartDto = await _serviceManager.CartService.GetByUserIdAsync(userid);

            return Ok(cartDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddCartItem(int userid, CartItemDto cartItemDto)
        {
            var cartDto = await _serviceManager.CartService.AddCartItemAsync(userid, cartItemDto);

            return Ok(cartDto);
        }
    }
}
