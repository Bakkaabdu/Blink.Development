namespace Blink.Development.Entities.Entities
{
    public class Blinki : BaseEntity
    {
        public ICollection<Branch>? Branches { get; set; }
        public ICollection<Order>? Orders { get; set; } // Blink can create orders
        public ICollection<Mission>? Missions { get; set; } // Blink manages money requests

    }
}
