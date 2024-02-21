﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICartRepository
    {
        Task<Cart?> GetByUserIdAsync(int userid);

        Task<bool> CreateAsync(int userId);

        Task<Cart> AddCartItemAsync(CartItem cartItem);

        Task<bool> ClearCartItemsAsync(int userid);

        Task UpdateCartItems(Cart cart);
    }
}
