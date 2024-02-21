using AutoMapper;
using Contracts;
using Domain.Entities;
using Domain.Repositories;
using Services.Abstractions;

namespace Services
{
    internal sealed class CartService : ICartService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CartService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<CartDto> AddCartItemAsync(int userid, CartItemDto cartItemDto)
        {
            if ((await _repositoryManager.CartRepository.GetByUserIdAsync(userid)) == null)
            {
                await CreateAsync(userid);

                await _repositoryManager.UnitOfWork.SaveChangesAsync();
            }

            Cart cart = await _repositoryManager.CartRepository.AddCartItemAsync(_mapper.Map<CartItem>(cartItemDto));

            await _repositoryManager.CartRepository.UpdateCartItems(cart);

            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            var cartDto = _mapper.Map<CartDto>(cart);

            return cartDto;
        }

        public async Task<bool> ClearCartItemsAsync(int userid)
        {
            return await _repositoryManager.CartRepository.ClearCartItemsAsync(userid);
        }

        public async Task<bool> CreateAsync(int userid)
        {
            return await _repositoryManager.CartRepository.CreateAsync(userid);
        }

        public async Task<CartDto> GetByUserIdAsync(int userid)
        {
            var cart = await _repositoryManager.CartRepository.GetByUserIdAsync(userid);

            var cartDto = _mapper.Map<CartDto>(cart);

            return cartDto;
        }

        public async Task UpdateCartItems(Cart cart)
        {
            await _repositoryManager.CartRepository.UpdateCartItems(cart);
        }
    }
}
