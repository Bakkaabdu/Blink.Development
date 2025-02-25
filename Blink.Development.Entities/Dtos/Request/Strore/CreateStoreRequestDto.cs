namespace Blink.Development.Entities.Dtos.Request.Strore;

public class CreateStoreRequestDto
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public Guid BranchId { get; set; }

}
