using SmartInventoryAPI.Models.Customer;
using SmartInventoryAPI.Repository.Interface;
using SmartInventoryAPI.Services.Interface;

namespace SmartInventoryAPI.Services.Implementation;

public class CustomerService:ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        return await _customerRepository.GetCustomersWithDetailsAsync();
    }

    public async Task<Customer?> GetCustomerByIdAsync(int customerId)
    {
        return await _customerRepository.GetCustomerWithDetailsByIdAsync(customerId);
    }

    public async Task<Customer> CreateCustomerAsync(Customer customer)
    {
        await _customerRepository.AddAsync(customer);
        return customer;
    }

    public async Task UpdateCustomerAsync(int customerId, Customer updatedCustomer)
    {
        var existingCustomer = await _customerRepository.GetCustomerWithDetailsByIdAsync(customerId);
        if (existingCustomer == null)
        {
            throw new KeyNotFoundException("Customer not found");
        }

        existingCustomer.FirstName = updatedCustomer.FirstName;
        existingCustomer.LastName = updatedCustomer.LastName;
        existingCustomer.Email = updatedCustomer.Email;
        existingCustomer.PhoneNumber = updatedCustomer.PhoneNumber;
        existingCustomer.Addresses = updatedCustomer.Addresses;

        await _customerRepository.UpdateAsync(existingCustomer);
    }

    public async Task DeleteCustomerAsync(int customerId)
    {
        await _customerRepository.DeleteAsync(customerId);
    }
}
