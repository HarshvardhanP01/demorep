using Microsoft.EntityFrameworkCore;
using BurgerShopAPI.Models;
namespace BurgerShopAPI.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=OrderDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

    }
}
