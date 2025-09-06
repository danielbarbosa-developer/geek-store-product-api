namespace GeekStore.ProductApi.Domain.Entities;

public class AuditEntity
{
    public string CreatedBy { get; set; } = null!;
    public string? UpdatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string CreatedByCorrelationId { get; set; } = null!;
    public string? UpdatedByCorrelationId { get; set; }
}