namespace Blink.Development.Entities.Dtos.Request.Inventory;

public class CreateInventoryRequestDto
{
    public string UserStoreId { get; set; }
    public string Name { get; set; }
    public required string ProductName { get; set; }
    public decimal Quantity { get; set; }
}
