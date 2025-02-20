namespace Blink.Development.Entities.Entities
{
    public class Delivery : BaseEntity
    {
        public required string PhoneNumber { get; set; }
        public required string Address { get; set; }
        public string Photo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string? IdentityCardPhoto { get; set; } = string.Empty;


        // Navigation Properties
        public Guid BranchId { get; set; }
        public required Branch Branch { get; set; }
        public decimal Balance { get; set; } // Money with delivery
        public Guid? MoneyTransactionId { get; set; }
        public MoneyTransaction? MoneyTransaction { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
