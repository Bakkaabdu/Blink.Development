namespace Blink.Development.Entities.Entities
{
    public class Street : BaseEntity
    {
        public Guid CityId { get; set; }
        public required City City { get; set; }
        public required decimal DeliveryPrice { get; set; }
    }
}
