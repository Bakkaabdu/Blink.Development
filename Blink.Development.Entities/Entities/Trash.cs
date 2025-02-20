namespace Blink.Development.Entities.Entities
{
    public class Trash : BaseEntity
    {
        public Guid OrderId { get; set; }
        public required Order Order { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
