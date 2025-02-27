using Microsoft.AspNetCore.Identity;

namespace Blink.Development.Entities.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
        // Store-Specific Properties (nullable)
        public string? StoreAddress { get; set; }
        public string? StorePhoneNumber { get; set; }
        public Guid? StoreBranchId { get; set; }
        public Branch? StoreBranch { get; set; }
        public ICollection<Inventory>? Inventory { get; set; }
        public Guid? StoreMoneyTransactionId { get; set; }
        public MoneyTransaction? StoreMoneyTransaction { get; set; }
        public Guid? MissionId { get; set; }
        public ICollection<Mission>? Mission { get; set; }

        // Delivery-Specific Properties (nullable)
        public string? DeliveryAddress { get; set; }
        public string? DeliveryPhoneNumber { get; set; }
        public Guid? DeliveryBranchId { get; set; }
        public Branch? DeliveryBranch { get; set; } // Navigation for Delivery Branch
        public decimal Balance { get; set; } = 0; // Delivery user's balance
        public Guid? DeliveryMoneyTransactionId { get; set; }
        public MoneyTransaction? DeliveryMoneyTransaction { get; set; }

        // Orders
        public ICollection<Order>? StoreOrders { get; set; } // Orders placed by this Store
        public ICollection<Order>? DeliveryOrders { get; set; } // Orders delivered by this Deli
    }
}
