namespace GeekStore.ProductApi.Domain.Entities;

public class Product : AuditEntity
{
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Brand { get; set; }
}