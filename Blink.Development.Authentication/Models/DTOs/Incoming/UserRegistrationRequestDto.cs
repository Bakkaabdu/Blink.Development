namespace Blink.Development.Authentication.Models.DTOs.Incoming;

public class UserRegistrationRequestDto
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Password { get; set; }
}
