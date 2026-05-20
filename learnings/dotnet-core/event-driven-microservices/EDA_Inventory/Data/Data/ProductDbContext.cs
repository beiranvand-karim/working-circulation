using Microsoft.EntityFrameworkCore;

namespace EDA_Customer.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", ProductId = new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), Quantity = 10 },
                new Product { Id = 2, Name = "Mouse", ProductId = new Guid("b2c3d4e5-f6a7-8901-bcde-f12345678901"), Quantity = 50 },
                new Product { Id = 3, Name = "Keyboard", ProductId = new Guid("c3d4e5f6-a7b8-9012-cdef-123456789012"), Quantity = 30 }
            );
        }
    }
}