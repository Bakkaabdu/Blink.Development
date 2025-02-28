namespace Blink.Development.Entities.Dtos.Request.Inventory;

public class UpdateInventoryRequestDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public required string ProductName { get; set; }
    public decimal Quantity { get; set; }
}
