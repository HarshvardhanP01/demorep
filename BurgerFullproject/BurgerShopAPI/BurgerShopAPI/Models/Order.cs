using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BurgerShopAPI.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int UniqueID { get; set; }   
        public string? BurgerName { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; }  
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
