namespace Blink.Development.Entities.Entities
{
    public class Customer : BaseEntity
    {
        public required string Phone { get; set; }
        public string Phone2 { get; set; } = string.Empty;
        public required ICollection<Order> Orders { get; set; }
    }
}
