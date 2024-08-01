using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BurgerProjectAPI.Models
{
    [Table("Purchase")]
    public class Orders
    {
        [Key]
        public int UniqueID { get; set; }
        public string? BurgerType { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
