namespace Blink.Development.Entities.Dtos.Response.Trash;

public class CreateTrashResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid OrderId { get; set; }
    public DateTime ReturnDate { get; set; }
}
