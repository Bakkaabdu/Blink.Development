namespace Blink.Development.Entities.Entities
{
    public class MoneyTransaction
    {
        public Guid Id { get; set; }
        public Guid? DeliveryId { get; set; }
        public Delivery? Delivery { get; set; }
        public Guid? StoreId { get; set; }
        public Store? Store { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}