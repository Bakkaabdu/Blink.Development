namespace Blink.Development.Entities.Dtos.Response.Mission;

public class CreateMissionResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string UserStoreId { get; set; }
    public ReturnType? IsTrashed { get; set; }
    public required TakeItBy TakeItBy { get; set; }
    public decimal? AmountRequested { get; set; }
    public DateTime RequestDate { get; set; }
    public bool IsCompleted { get; set; }
}
