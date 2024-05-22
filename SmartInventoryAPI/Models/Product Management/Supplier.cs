namespace SmartInventoryAPI.Models.Product_Management;

public class Supplier
{
    public int SupplierId { get; set; }
    public string Name { get; set; }
    public string ContactInformation { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public ICollection<Product> Products { get; set; }
}
