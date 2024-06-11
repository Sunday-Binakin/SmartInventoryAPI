using SmartInventoryAPI.Models.Customer;

namespace SmartInventoryAPI.Repository.Interface;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<IEnumerable<Customer>> GetCustomersWithDetailsAsync();
    Task<Customer?> GetCustomerWithDetailsByIdAsync(int customerId);
}