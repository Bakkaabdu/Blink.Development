namespace Blink.Development.Entities.Entities
{
    public class Inventory : BaseEntity
    {
        public Guid StoreId { get; set; }
        public required Store Store { get; set; }
        public required string ProductName { get; set; }
        public decimal Quantity { get; set; }
    }
}
