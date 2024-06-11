using SmartInventoryAPI.Models;
using SmartInventoryAPI.Repository.Interface;
using SmartInventoryAPI.Services.Interface;

namespace SmartInventoryAPI.Services.Implementation;

public class OrderService:IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await _orderRepository.GetOrdersWithDetailsAsync();
    }

    public async Task<Order?> GetOrderByIdAsync(int orderId)
    {
        return await _orderRepository.GetOrderWithDetailsByIdAsync(orderId);
    }

    public async Task<Order> CreateOrderAsync(Order order)
    {
        await _orderRepository.AddAsync(order);
        return order;
    }

    public async Task UpdateOrderAsync(int orderId, Order updatedOrder)
    {
        var existingOrder = await _orderRepository.GetOrderWithDetailsByIdAsync(orderId);
        if (existingOrder == null)
        {
            throw new KeyNotFoundException("Order not found");
        }

        existingOrder.CustomerId = updatedOrder.CustomerId;
        existingOrder.OrderDate = updatedOrder.OrderDate;
        existingOrder.Status = updatedOrder.Status;
        existingOrder.OrderItems = updatedOrder.OrderItems;

        await _orderRepository.UpdateAsync(existingOrder);
    }

    public async Task DeleteOrderAsync(int orderId)
    {
        await _orderRepository.DeleteAsync(orderId);
    }
}