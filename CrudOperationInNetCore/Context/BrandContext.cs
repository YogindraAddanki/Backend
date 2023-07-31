using CrudOperationInNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudOperationInNetCore.Context
{
    public class BrandContext : DbContext
    {
        public BrandContext(DbContextOptions<BrandContext> options) : base(options)
        {

        }
        public DbSet<Brand> Brands { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customer { get; set; }

    }
}
