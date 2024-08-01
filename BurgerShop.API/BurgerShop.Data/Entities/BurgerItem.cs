using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerShop.Data.Entities
{
    public class BurgerItem
    {
        public int Id { get; set; }
        public string? BurgerType { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; }
    }
}
