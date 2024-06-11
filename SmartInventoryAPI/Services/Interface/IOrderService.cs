using SmartInventoryAPI.Models;

namespace SmartInventoryAPI.Services.Interface;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<Order?> GetOrderByIdAsync(int orderId);
    Task<Order> CreateOrderAsync(Order order);
    Task UpdateOrderAsync(int orderId, Order order);
    Task DeleteOrderAsync(int orderId);
}