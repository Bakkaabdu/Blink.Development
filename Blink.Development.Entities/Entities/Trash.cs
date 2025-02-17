namespace Blink.Development.Entities.Entities
{
    public class Trash : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order? Order { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
