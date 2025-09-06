namespace GeekStore.ProductApi.Domain.Dtos;

public class ProductDto
{
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Brand { get; set; }
}