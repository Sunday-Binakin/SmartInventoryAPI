using SmartInventoryAPI.Models.Product_Management;
using SmartInventoryAPI.Repository;
using SmartInventoryAPI.Services.Interface;

namespace SmartInventoryAPI.Services.Implementation;

public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _supplierRepository;

    public SupplierService(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
    {
        return await _supplierRepository.GetAllAsync();
    }

    public async Task<Supplier> GetSupplierByIdAsync(int id)
    {
        return await _supplierRepository.GetByIdAsync(id);
    }

    public async Task AddSupplierAsync(Supplier supplier)
    {
        await _supplierRepository.AddAsync(supplier);
    }

    public async Task UpdateSupplierAsync(Supplier supplier)
    {
        await _supplierRepository.UpdateAsync(supplier);
    }

    public async Task DeleteSupplierAsync(int id)
    {
        await _supplierRepository.DeleteAsync(id);
    }
}
