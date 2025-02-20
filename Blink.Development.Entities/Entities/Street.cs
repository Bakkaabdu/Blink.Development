namespace Blink.Development.Entities.Entities
{
    public class Street : BaseEntity
    {
        public Guid CityId { get; set; }
        public required City City { get; set; }
        public required ICollection<Order> Orders { get; set; } // the perpus of this is to add the amount (price) of the order to the delivery price if the order is not delivered we are not gonna do the transaction and if the the boolian ( isPaid ) is true we are not gonna do the transaction ( if the ispaid true we gonna take the profit form the amount of money from the amount of the order and if the ispaid is false we gonna add it to the amount of the order and the money coming from the customer)
        public required decimal DeliveryPrice { get; set; }
        public required decimal BlinkProfit { get; set; }
    }
}