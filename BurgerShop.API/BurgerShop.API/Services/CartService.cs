using BurgerShop.Data;
using BurgerShop.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BurgerShop.API;
using BurgerShop.Data.Entities;


namespace BurgerShop.API.Services
{
    public class CartService
    {

        private readonly BurgerShopDbContext _context;

        public CartService(BurgerShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<CartItem>> GetCartItemsAsync()
        {
            return await _context.CartItems.ToListAsync();
        }

        public async Task AddToCartAsync(CartItem item)
        {
            _context.CartItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFromCartAsync(int id)
        {
            var item = await _context.CartItems.FindAsync(id);
            if (item != null)
            {
                _context.CartItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
