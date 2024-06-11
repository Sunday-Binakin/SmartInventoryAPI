using SmartInventoryAPI.Data;
using SmartInventoryAPI.Models.Product_Management;
using SmartInventoryAPI.Repository.Interface;

namespace SmartInventoryAPI.Repository.Implementation;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(SmartInventoryDbContext context) : base(context) { }
}