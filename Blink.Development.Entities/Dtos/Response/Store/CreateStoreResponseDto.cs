namespace Blink.Development.Entities.Dtos.Response.Store;

public class CreateStoreResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid BranchId { get; set; }
    public Blink.Development.Entities.Entities.Branch Branch { get; set; }
}
