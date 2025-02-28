using Blink.Development.Entities.Entities;

namespace Blink.Development.Entities
{
    public enum TakeItBy
    {
        ComingToBlink = 1,
        WithDelivery = 2
    }
    public enum ReturnType
    {
        Collection = 1, // تجميع
        Settlement = 2, // تسوية
        Return_Delivery = 3 // تسليم مرتجعات
    }

    public class Mission : BaseEntity
    {
        public string UserStoreId { get; set; }
        public required User UserStore { get; set; }
        public ReturnType? IsTrashed { get; set; }
        public required TakeItBy TakeItBy { get; set; }

        public decimal? AmountRequested { get; set; }
        public DateTime RequestDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
