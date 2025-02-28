namespace Blink.Development.Entities.Dtos.Request.Trash;

public class CreateTrashRequestDto
{
    public string Name { get; set; }
    public Guid OrderId { get; set; }
    public DateTime ReturnDate { get; set; }
}
