using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ClodeMonnetV2.Model;

public sealed class RestaurantDbContext : DbContext
{
    public RestaurantDbContext(/*DbContextOptions options*/) /*: base(options)*/
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<PurchaseRequest> PurchaseRequests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=ClodeMonnet.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Menu>()
            .HasKey(m => new { m.MenuId });

        modelBuilder.Entity<PurchaseRequest>()
            .HasKey(m => new { m.RequestId, m.UserId });

        modelBuilder.Entity<Menu>()
            .HasOne(m => m.Dish)
            .WithMany(d => d.Menus)
            .HasForeignKey(m => m.DishId);

        modelBuilder.Entity<OrderItem>()
            .HasKey(oi => new { oi.OrderItemId, oi.OrderId, oi.DishId });

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId);

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Dish)
            .WithMany(d => d.OrderItems)
            .HasForeignKey(oi => oi.DishId);

        modelBuilder.Entity<Report>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reports)
            .HasForeignKey(r => r.UserId);

        modelBuilder.Entity<PurchaseRequest>()
            .HasOne(pr => pr.User)
            .WithMany(u => u.PurchaseRequests)
            .HasForeignKey(pr => pr.UserId);

        modelBuilder.Entity<List<string>>().HasNoKey();

        base.OnModelCreating(modelBuilder);
    }
}