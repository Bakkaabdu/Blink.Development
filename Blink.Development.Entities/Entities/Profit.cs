namespace Blink.Development.Entities.Entities
{
    public class Profit
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public Store? Store { get; set; }
        public Guid DeliveryId { get; set; }
        public Delivery? Delivery { get; set; }
        public decimal BlinkProfit { get; set; }
        public decimal StoreProfit { get; set; }
        public decimal DeliveryProfit { get; set; }
    }
}
