using Microsoft.EntityFrameworkCore;
using SmartInventoryAPI.Data;
using SmartInventoryAPI.Models.Product_Management;

namespace SmartInventoryAPI.Repository.Implementation;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(SmartInventoryDbContext context) : base(context) { }

    
    public override async Task<IEnumerable<Product?>> GetAllAsync()
    {
        return await _entities.Include(p => p.Category)
            .Include(p => p.Supplier)
            .ToListAsync();
    }

    public override async Task<Product?> GetByIdAsync(int id)
    {
        return await _entities.Include(p => p.Category.Name)
            .Include(p => p.Supplier)
            .ThenInclude(b => b.Name) 
            .FirstOrDefaultAsync(p => p.ProductId == id);
    }
}