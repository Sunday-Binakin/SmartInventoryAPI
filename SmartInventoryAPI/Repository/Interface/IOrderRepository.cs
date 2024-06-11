using SmartInventoryAPI.Models;

namespace SmartInventoryAPI.Repository.Interface;

public interface IOrderRepository : IRepository<Order>
{
    Task<IEnumerable<Order>> GetOrdersWithDetailsAsync();
    Task<Order?> GetOrderWithDetailsByIdAsync(int orderId);
}