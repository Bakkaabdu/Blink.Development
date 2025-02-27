namespace Blink.Development.Entities.Entities
{
    public class Inventory : BaseEntity
    {
        public string UserStoreId { get; set; }
        public required User UserStore { get; set; }
        public required string ProductName { get; set; }
        public decimal Quantity { get; set; }
    }
}
