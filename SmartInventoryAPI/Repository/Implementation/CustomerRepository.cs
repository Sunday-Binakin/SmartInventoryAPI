using Microsoft.EntityFrameworkCore;
using SmartInventoryAPI.Data;
using SmartInventoryAPI.Models.Customer;
using SmartInventoryAPI.Repository.Interface;

namespace SmartInventoryAPI.Repository.Implementation;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(SmartInventoryDbContext context) : base(context) { }

    public async Task<IEnumerable<Customer>> GetCustomersWithDetailsAsync()
    {
        return await _entities.Include(c => c.Addresses)
            .Include(c => c.Orders)
            .ToListAsync();
    }

    public async Task<Customer?> GetCustomerWithDetailsByIdAsync(int customerId)
    {
        return await _entities.Include(c => c.Addresses)
            .Include(c => c.Orders)
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);
    }
}