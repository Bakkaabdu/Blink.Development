namespace Blink.Development.Entities.Entities
{
    public class MoneyTransaction
    {
        public Guid Id { get; set; }
        public string? DeliveryUserId { get; set; }
        public User? DeliveryUser { get; set; }
        public string? UserStoreId { get; set; }
        public User? UserStore { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}