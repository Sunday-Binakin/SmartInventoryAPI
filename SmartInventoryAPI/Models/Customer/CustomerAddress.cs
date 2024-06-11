namespace SmartInventoryAPI.Models.Customer;

public class CustomerAddress
{
    public int CustomerAddressId { get; set; }
    public int CustomerId { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public Customer Customer { get; set; }
}