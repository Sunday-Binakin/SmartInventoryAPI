using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
    }
}