using Microsoft.EntityFrameworkCore;
using BurgerShop.Data.Entities;

namespace BurgerShop.Data
{
    public class BurgerShopDbContext:DbContext
    {
        public BurgerShopDbContext(DbContextOptions<BurgerShopDbContext> options) : base(options) { }

        public DbSet<BurgerItem> BurgerItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BurgerItem>()
                .Property(b => b.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<CartItem>()
                .Property(c => c.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
