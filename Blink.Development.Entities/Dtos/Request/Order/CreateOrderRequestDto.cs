using Blink.Development.Entities.Entities;
using System.ComponentModel.DataAnnotations;

namespace Blink.Development.Entities.Dtos.Request.Order
{
    public class CreateOrderRequestDto
    {
        [Required(ErrorMessage = "Order name is required")]
        [StringLength(200, ErrorMessage = "Name cannot exceed 200 characters")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price cannot be negative")]
        public decimal Price { get; set; }

        [StringLength(1000, ErrorMessage = "Note cannot exceed 1000 characters")]
        public string? Note { get; set; }

        [StringLength(2000, ErrorMessage = "Description cannot exceed 2000 characters")]
        public string? Description { get; set; }

        public bool IsPaid { get; set; }
        public bool CanOpen { get; set; }
        public bool Packaging { get; set; }
        public bool CanTry { get; set; }
        public bool CanPay50 { get; set; }

        [Display(Name = "Big Shipments Price")]
        public bool BigShipmentsPrice { get; set; }  // Corrected naming

        [Required(ErrorMessage = "Customer ID is required")]
        public Guid CustomerId { get; set; }

        [Required(ErrorMessage = "City ID is required")]
        public Guid CityId { get; set; }

        public Guid? StreetId { get; set; }
        public Guid? BranchId { get; set; }
        public Guid? TrashId { get; set; }

        [Required(ErrorMessage = "Order status is required")]
        public OrderStatus Status { get; set; }

        public string? UserStoreId { get; set; }  // Assuming string for ASP.NET Core Identity
        public string? DeliveryUserId { get; set; }  // Assuming string for ASP.NET Core Identity
    }
}