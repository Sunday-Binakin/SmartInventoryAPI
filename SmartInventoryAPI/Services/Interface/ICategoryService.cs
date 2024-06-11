using SmartInventoryAPI.Models.Product_Management;

namespace SmartInventoryAPI.Services.Interface;

public interface ICategoryService
{
    Task<IEnumerable<Category?>> GetAllCategoriesAsync();
    Task<Category?> GetCategoryByIdAsync(int id);
    Task AddCategoryAsync(Category? category);
    Task UpdateCategoryAsync(Category? category);
    Task DeleteCategoryAsync(int id);
}