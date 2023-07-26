using Microsoft.EntityFrameworkCore;

namespace CrudOperationInNetCore.Models
{
    public class BrandContext : DbContext
    {
        public BrandContext(DbContextOptions<BrandContext> options): base(options)
        {

        }
        public DbSet<Brand> Brands { get; set; }

        public DbSet<Order> Orders { get; set; }

    }
}
