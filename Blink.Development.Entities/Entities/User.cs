using Microsoft.AspNetCore.Identity;

namespace Blink.Development.Entities.Entities
{
    public enum UserType
    {
        Store = 0,
        Delivery = 1
    }
    public class User : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
        public required UserType TypeOfUser { get; set; }
        // Store-Specific Properties (nullable)
        public string? StoreAddress { get; set; }
        public string? StorePhoneNumber { get; set; }
        public Guid? StoreBranchId { get; set; } = null;
        public Branch? StoreBranch { get; set; } = null;
        public ICollection<Inventory>? Inventory { get; set; }
        public Guid? StoreMoneyTransactionId { get; set; }
        //public decimal? StoreBalance { get; set; }
        public MoneyTransaction? StoreMoneyTransaction { get; set; }
        public ICollection<Mission>? Mission { get; set; }

        // Delivery-Specific Properties (nullable)
        public string? DeliveryAddress { get; set; }
        public string? DeliveryPhoneNumber { get; set; }
        public Guid? DeliveryBranchId { get; set; } = null;
        public Branch? DeliveryBranch { get; set; } = null;
        public decimal Balance { get; set; } = 0; // Delivery user's balance
        public Guid? DeliveryMoneyTransactionId { get; set; }
        public MoneyTransaction? DeliveryMoneyTransaction { get; set; }

        // Orders
        public ICollection<Order>? StoreOrders { get; set; } // Orders placed by this Store
        public ICollection<Order>? DeliveryOrders { get; set; } // Orders delivered by this Deli
    }
}
