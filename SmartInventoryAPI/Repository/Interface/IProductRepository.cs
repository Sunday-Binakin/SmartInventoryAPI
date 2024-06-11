using SmartInventoryAPI.Models.Product_Management;
using SmartInventoryAPI.Repository.Interface;

namespace SmartInventoryAPI.Repository;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product?>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
}