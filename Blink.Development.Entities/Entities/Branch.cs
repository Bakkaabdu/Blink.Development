namespace Blink.Development.Entities.Entities
{
    public class Branch : BaseEntity
    {
        public ICollection<Store>? Stores { get; set; }
        public ICollection<Delivery>? Deliveries { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
