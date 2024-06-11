using Microsoft.EntityFrameworkCore;
using SmartInventoryAPI.Data;
using SmartInventoryAPI.Models;
using SmartInventoryAPI.Repository.Interface;

namespace SmartInventoryAPI.Repository.Implementation;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(SmartInventoryDbContext context) : base(context) { }

    public async Task<IEnumerable<Order>> GetOrdersWithDetailsAsync()
    {
        return await _entities.Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            //.Include(o => o.Customer)
            .ToListAsync();
    }

    public async Task<Order?> GetOrderWithDetailsByIdAsync(int orderId)
    {
        return await _entities.Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            // .Include(o => o.Customer)
            .FirstOrDefaultAsync(o => o.OrderId == orderId);
    }
}