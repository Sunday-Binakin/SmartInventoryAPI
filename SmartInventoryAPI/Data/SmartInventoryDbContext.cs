using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartInventoryAPI.Models;
using SmartInventoryAPI.Models.Customer;
using SmartInventoryAPI.Models.Product_Management;

namespace SmartInventoryAPI.Data;

public class SmartInventoryDbContext : IdentityDbContext<IdentityUser>
{
    public SmartInventoryDbContext(DbContextOptions<SmartInventoryDbContext> options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerAddress> CustomerAddresses { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Configure Product
        builder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.ProductId);
            entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
            entity.Property(p => p.Price).HasColumnType("decimal(18,2)");
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");

            entity.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            entity.HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierId);
        });

        // Configure Category
        builder.Entity<Category>(entity =>
        {
            entity.HasKey(c => c.CategoryId);
            entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
            entity.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");
        });

        // Configure Supplier
        builder.Entity<Supplier>(entity =>
        {
            entity.HasKey(s => s.SupplierId);
            entity.Property(s => s.Name).IsRequired().HasMaxLength(100);
            entity.Property(s => s.CreatedAt).HasDefaultValueSql("GETDATE()");
        });
        // Configurations for Order
        builder.Entity<Order>()
            .HasKey(o => o.OrderId);

        builder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId);

        builder.Entity<Order>()
            .HasMany(o => o.OrderItems)
            .WithOne(oi => oi.Order)
            .HasForeignKey(oi => oi.OrderId);

        // Configurations for OrderItem
        builder.Entity<OrderItem>()
            .HasKey(oi => oi.OrderItemId);

        builder.Entity<OrderItem>()
            .HasOne(oi => oi.Product)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(oi => oi.ProductId);
        // Configurations for Customer
        builder.Entity<Customer>()
            .HasKey(c => c.CustomerId);

        builder.Entity<Customer>()
            .HasMany(c => c.Addresses)
            .WithOne(a => a.Customer)
            .HasForeignKey(a => a.CustomerId);

        // Configurations for CustomerAddress
        builder.Entity<CustomerAddress>()
            .HasKey(ca => ca.CustomerAddressId);
    }
}