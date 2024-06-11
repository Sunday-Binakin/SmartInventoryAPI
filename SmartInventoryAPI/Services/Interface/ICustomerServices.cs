using SmartInventoryAPI.Models.Customer;

namespace SmartInventoryAPI.Services.Interface;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    Task<Customer?> GetCustomerByIdAsync(int customerId);
    Task<Customer> CreateCustomerAsync(Customer customer);
    Task UpdateCustomerAsync(int customerId, Customer customer);
    Task DeleteCustomerAsync(int customerId);
}