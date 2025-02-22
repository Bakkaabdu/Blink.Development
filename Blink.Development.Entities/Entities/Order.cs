namespace Blink.Development.Entities.Entities
{
    public class Order : BaseEntity
    {
        public Guid RandomOrderGuid { get; set; } = Guid.NewGuid();
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Note { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsPaid { get; set; } = false;// the store is responsible for the payment for the delivering price
        public bool CanOpen { get; set; }
        public bool Packaging { get; set; }
        public bool CanTry { get; set; }
        public bool CanPay50 { get; set; }
        public bool bigShipmentsPrice { get; set; }


        // relationships
        public Guid StoreId { get; set; }
        public required Store Store { get; set; } // the order has one store and the store has many orders // done
        public Guid CustomerId { get; set; }
        public required Customer Customer { get; set; } // the order has one customer and the customer has many orders // done
        public Guid? DeliveryId { get; set; }
        public Delivery? Delivery { get; set; } // the order has one delivery and the delivery has many orders 
        public Guid StatusId { get; set; }
        public required Status Status { get; set; } // the order has one status and the status has many orders => the status is like "Pending", "Delivered", "Canceled", etc. => the status is an enum => the status is a lookup table => the status is a reference table => the status is a master table
        public Guid CityId { get; set; }
        public required City City { get; set; } // the order has one city and the city has many orders
        public Guid? StreetId { get; set; }
        public Street? Street { get; set; } = null!;// the order has one street and the street has many orders
        public Guid? BranchId { get; set; }
        public Branch? Branch { get; set; }
        public Guid TrashId { get; set; }
        public Trash? Trash { get; set; }
    }
}
