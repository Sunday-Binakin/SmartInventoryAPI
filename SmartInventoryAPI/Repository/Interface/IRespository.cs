using SmartInventoryAPI.Models.Product_Management;

namespace SmartInventoryAPI.Repository;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}
public interface IProductRepository : IRepository<Product> { }
public interface ICategoryRepository : IRepository<Category> { }
public interface ISupplierRepository : IRepository<Supplier> { }