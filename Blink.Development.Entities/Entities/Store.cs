namespace Blink.Development.Entities.Entities
{
    public class Store : BaseEntity
    {
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        //public string StoreType { get; set; } = string.Empty; // the store type like "Grocery", "Pharmacy", "Restaurant", etc.

        public Guid BranchId { get; set; }
        public required Branch Branch { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<Inventory>? Inventory { get; set; }
    }
}
