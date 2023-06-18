using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ClodeMonnetV2.Model
{
    public sealed class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Report> Reports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlite("Data Source=ClodeMonnet.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>()
                .HasMany(d => d.Ingredients)
                .WithMany(i => i.Dishes)
                .UsingEntity<Dictionary<string, object>>(
                    "DishIngredient",
                    j => j.HasOne<Ingredient>().WithMany().HasForeignKey("IngredientId"),
                    j => j.HasOne<Dish>().WithMany().HasForeignKey("DishId")
                );

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderId, oi.DishId });

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Dish)
                .WithMany()
                .HasForeignKey(oi => oi.DishId);

            modelBuilder.Entity<Report>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId);
        }
    }
}
