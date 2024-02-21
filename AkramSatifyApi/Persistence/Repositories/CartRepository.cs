using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class CartRepository : RepositoryBase<Cart>, ICartRepository
    {
        public CartRepository(RepositoryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Cart> AddCartItemAsync(CartItem cartItem)
        {
            var cart = await FindByCondition(c => c.Id == cartItem.CartId).FirstAsync();

            cart.CartItems.Add(cartItem);

            return cart;
        }

        public async Task<bool> ClearCartItemsAsync(int userid)
        {
            var cart = await FindByCondition(c => c.UserId == userid).Include(c => c.CartItems).FirstAsync();

            cart.CartItems.Clear();

            return true;
        }

        public async Task<bool> CreateAsync(int userId)
        {
            Create(new Cart()
            {
                UserId = userId,
            });

           return true;
        }

        public async Task<Cart?> GetByUserIdAsync(int userid) => await FindByCondition(c => c.UserId == userid).Include(c => c.User).Include(c => c.CartItems).ThenInclude(ci => ci.Product).FirstOrDefaultAsync();

        public async Task UpdateCartItems(Cart cart)
        {
            Update(cart);
            await SaveChanges();
        }
    }
}
