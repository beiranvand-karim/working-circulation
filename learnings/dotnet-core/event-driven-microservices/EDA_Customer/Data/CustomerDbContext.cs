using Microsoft.EntityFrameworkCore;

namespace EDA_Customer.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", ProductId = new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), Quantity = 10 },
                new Product { Id = 2, Name = "Mouse", ProductId = new Guid("b2c3d4e5-f6a7-8901-bcde-f12345678901"), Quantity = 50 },
                new Product { Id = 3, Name = "Keyboard", ProductId = new Guid("c3d4e5f6-a7b8-9012-cdef-123456789012"), Quantity = 30 }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Alice", ProductId = new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), ItemsInCart = 2 },
                new Customer { Id = 2, Name = "Bob", ProductId = new Guid("b2c3d4e5-f6a7-8901-bcde-f12345678901"), ItemsInCart = 1 },
                new Customer { Id = 3, Name = "Charlie", ProductId = new Guid("c3d4e5f6-a7b8-9012-cdef-123456789012"), ItemsInCart = 3 }
            );
        }
    }
}