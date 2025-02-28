using Blink.Development.Entities.Entities;

namespace Blink.Development.Entities.Dtos.Response.Order;

public class CreateOrderResponseDto
{
    public Guid Id { get; set; }
    public Guid RandomOrderGuid { get; set; }
    public string Name { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string? Note { get; set; }
    public string? Description { get; set; }
    public bool IsPaid { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }

    // Relationships (IDs only)
    public Guid CustomerId { get; set; }
    public Guid CityId { get; set; }
    public Guid? StreetId { get; set; }
    public Guid? BranchId { get; set; }
    public Guid? TrashId { get; set; }
    public string? UserStoreId { get; set; }
    public string? DeliveryUserId { get; set; }

    // Calculated/Helper Fields
    public decimal Total => Price * Quantity;
    public string StatusDisplayName => Status.ToString();
}
