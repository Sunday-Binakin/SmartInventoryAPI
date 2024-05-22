using SmartInventoryAPI.Models.Product_Management;

namespace SmartInventoryAPI.Services.Interface;

public interface ISupplierService
{
    Task<IEnumerable<Supplier>> GetAllSuppliersAsync();
    Task<Supplier> GetSupplierByIdAsync(int id);
    Task AddSupplierAsync(Supplier supplier);
    Task UpdateSupplierAsync(Supplier supplier);
    Task DeleteSupplierAsync(int id);
}