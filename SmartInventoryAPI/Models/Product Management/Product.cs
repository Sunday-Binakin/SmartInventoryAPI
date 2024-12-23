namespace SmartInventoryAPI.Models.Product_Management;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public int CategoryId { get; set; }
    public int SupplierId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public Category Category { get; set; }
    public Supplier Supplier { get; set; }
    
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>(); // Collection navigation property
}
