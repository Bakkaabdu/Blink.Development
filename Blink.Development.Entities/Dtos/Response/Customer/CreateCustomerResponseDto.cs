namespace Blink.Development.Entities.Dtos.Response.Customer;

public class CreateCustomerResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string? Phone2 { get; set; }
}
