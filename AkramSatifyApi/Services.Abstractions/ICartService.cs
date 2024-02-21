using Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface ICartService
    {
        Task<CartDto> GetByUserIdAsync(int userid);

        Task<bool> CreateAsync(int userid);

        Task<CartDto> AddCartItemAsync(int userid, CartItemDto cartItemDto);

        Task<bool> ClearCartItemsAsync(int userid);

        Task UpdateCartItems(Cart cart);
    }
}
