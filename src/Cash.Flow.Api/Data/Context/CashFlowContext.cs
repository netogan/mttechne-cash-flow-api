using Cash.Flow.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Cash.Flow.Api.Data.Context
{
    public class CashFlowContext(DbContextOptions<CashFlowContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e=> e.Password).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Transaction>(entity => 
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Amount).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.Type).IsRequired();
            });

            modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Username = "admin",
                Password = BCrypt.Net.BCrypt.HashPassword("adminpassword")
            });
        }
    }
}