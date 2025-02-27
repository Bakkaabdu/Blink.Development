namespace Blink.Development.Entities.Dtos.Request.Customer;

public class UpdateCustomerRequestDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string? Phone2 { get; set; }
}
