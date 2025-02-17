namespace Blink.Development.Entities.Entities
{
    public class City : BaseEntity
    {
        public required ICollection<Street> Streets { get; set; }
        public required ICollection<Order> Orders { get; set; }
    }
}
