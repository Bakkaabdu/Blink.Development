using Blink.Development.Entities.Entities;

namespace Blink.Development.Entities.Dtos.Request.Order
{
    public class UpdateOrderRequestDto
    {
        public Guid? Id { get; set; } // Order Id to identify the order to update
        public string? Name { get; set; } // Optional, in case you want to update the order name
        public int? Quantity { get; set; } // Quantity of items in the order
        public decimal? Price { get; set; } // Price of the order
        public string? Note { get; set; } // Optional note for the order
        public string? Description { get; set; } // Optional description for the order
        public bool? IsPaid { get; set; } // Whether the order is paid
        public bool? CanOpen { get; set; } // Whether the order can be opened
        public bool? Packaging { get; set; } // Whether the order is packaged
        public bool? CanTry { get; set; } // Whether the order can be tried
        public bool? CanPay50 { get; set; } // Whether the order can pay 50%
        public bool? BigShipmentsPrice { get; set; } // Whether the order has a big shipment price
        public Guid? CityId { get; set; } // City of the order
        public Guid? StreetId { get; set; } // Optional street of the order
        public Guid? BranchId { get; set; } // Optional branch of the order
        public Guid? TrashId { get; set; } // Optional trash Id for the order
        public OrderStatus? Status { get; set; } // Status of the order (use Enum)
    }
}
