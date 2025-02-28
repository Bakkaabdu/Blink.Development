namespace Blink.Development.Entities.Dtos.Response.Inventory;

public class CreateInventoryResponseDto
{
    public Guid Id { get; set; }
    public string UserStoreId { get; set; }
    public string Name { get; set; }
    public required string ProductName { get; set; }
    public decimal Quantity { get; set; }
}
