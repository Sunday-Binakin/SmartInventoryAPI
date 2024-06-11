using SmartInventoryAPI.Data;
using SmartInventoryAPI.Models.Product_Management;
using SmartInventoryAPI.Repository.Interface;

namespace SmartInventoryAPI.Repository.Implementation;

public class SupplierRepository : Repository<Supplier>, ISupplierRepository
{
    public SupplierRepository(SmartInventoryDbContext context) : base(context) { }
}