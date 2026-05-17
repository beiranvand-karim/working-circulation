using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrganumatorMssql.Models;

namespace OrganumatorMssql.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Portfolio> Portfolios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Portfolio>(s => s.HasKey(p => new { p.AppUserId, p.StockId }));

            builder.Entity<Portfolio>()
            .HasOne(s => s.AppUser)
            .WithMany(u => u.Portfolios)
            .HasForeignKey(d => d.AppUserId);

            builder.Entity<Portfolio>()
            .HasOne(s => s.Stock)
            .WithMany(u => u.Portfolios)
            .HasForeignKey(d => d.StockId);

            List<IdentityRole> identityRoles = new()
            {
                new() {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new() {
                    Name = "User",
                    NormalizedName = "USER"
                }
            };

            builder.Entity<IdentityRole>().HasData(identityRoles);
        }
    }


}
