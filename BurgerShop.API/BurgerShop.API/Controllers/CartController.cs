using Microsoft.AspNetCore.Mvc;
using BurgerShop.Data.Entities;
using BurgerShop.API.Models;
using BurgerShop.API.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using BurgerShop.Data.Entities;
using BurgerShop.API.Models;
using BurgerShop.API.Services;

namespace BurgerShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CartItem>>> GetCartItems()
        {
            var items = await _cartService.GetCartItemsAsync();
            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult<CartItem>> AddToCart([FromBody] CartItemModel itemModel)
        {
            var item = new CartItem
            {
                BurgerType = itemModel.BurgerType,
                Category = itemModel.Category,
                Price = itemModel.Price,
                Quantity = itemModel.Quantity
            };

            await _cartService.AddToCartAsync(item);
            return CreatedAtAction(nameof(GetCartItems), new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            await _cartService.RemoveFromCartAsync(id);
            return NoContent();
        }
    }
}
