using Microsoft.EntityFrameworkCore;
using WEBAPI.Models;

namespace WEBAPI.Data
{

    public class CompanyDbContext:DbContext
    {
        public DbSet<Dept> Departments { get; set; }
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options):base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(LocalDB)\\MsSqlLocalDB;Database=CompanyDB;Trusted_Connection=True;MultipleActiveResultSets=True;Trust Server Certificate=True");

            }       }
    }
}
