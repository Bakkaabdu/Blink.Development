namespace Blink.Development.Entities.Entities
{
    public class Branch : BaseEntity
    {
        public ICollection<User>? UserStores { get; set; }
        public ICollection<User>? DeliveryUsers { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
