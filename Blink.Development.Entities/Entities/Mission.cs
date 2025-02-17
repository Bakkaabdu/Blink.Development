using Blink.Development.Entities.Entities;

namespace Blink.Development.Entities
{
    public enum TakeItBy
    {
        ComingToBlink,
        WithDelivery
    }
    public enum ReturnType
    {
        Collection,
        Settlement,
        Return_Delivery
    }

    public class Mission : BaseEntity
    {
        public Guid StoreId { get; set; }
        public required Store Store { get; set; }
        public ReturnType? IsTrashed { get; set; } // enum
        public required TakeItBy TakeItBy { get; set; } // enum
        public ICollection<Order>? Orders { get; set; } // mission is like asking the company to take the order and deliver it

        public decimal? AmountRequested { get; set; }
        public DateTime RequestDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
