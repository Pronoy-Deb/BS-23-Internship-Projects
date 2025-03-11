using Microsoft.EntityFrameworkCore;
using Product_Management_Application.Models;

namespace Product_Management_Application.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
