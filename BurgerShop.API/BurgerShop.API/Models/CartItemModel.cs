namespace BurgerShop.API.Models
{
    public class CartItemModel
    {
        public string? BurgerType { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
