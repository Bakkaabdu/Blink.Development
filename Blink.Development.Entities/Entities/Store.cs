namespace Blink.Development.Entities.Entities
{
    public class Store : BaseEntity
    {
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        //public string StoreType { get; set; } = string.Empty; // the store type like "Grocery", "Pharmacy", "Restaurant", etc.

        public Guid BranchId { get; set; }
        public required Branch Branch { get; set; }
        public ICollection<Order>? Orders { get; set; } // done 
        public ICollection<Inventory>? Inventory { get; set; }
        public Guid? MoneyTransactionId { get; set; }
        public MoneyTransaction? MoneyTransaction { get; set; }
        public Guid? MissionId { get; set; }
        public ICollection<Mission>? Mission { get; set; }
    }
}
