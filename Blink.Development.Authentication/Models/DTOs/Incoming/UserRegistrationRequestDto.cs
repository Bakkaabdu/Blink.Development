using System.ComponentModel.DataAnnotations;

namespace Blink.Development.Authentication.Models.DTOs.Incoming;

public class UserRegistrationRequestDto
{

    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Password { get; set; }

    [Required]
    public required UserType UserType { get; set; } // Enum to differentiate user types

    public string? StoreAddress { get; set; }
    public string? StorePhoneNumber { get; set; }
    public Guid? StoreBranchId { get; set; } = null;

    // Delivery-Specific Properties
    public string? DeliveryAddress { get; set; }
    public string? DeliveryPhoneNumber { get; set; }
    public Guid? DeliveryBranchId { get; set; } = null;
}

public enum UserType
{
    Store = 0,
    Delivery = 1,
}
