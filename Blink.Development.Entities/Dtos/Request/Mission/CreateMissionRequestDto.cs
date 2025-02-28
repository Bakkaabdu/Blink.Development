namespace Blink.Development.Entities.Dtos.Request.Mission
{
    public class CreateMissionRequestDto
    {
        public string Name { get; set; }
        public string UserStoreId { get; set; }
        public ReturnType? IsTrashed { get; set; }
        public required TakeItBy TakeItBy { get; set; }
        public decimal? AmountRequested { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
        public bool IsCompleted { get; set; }
    }
}
