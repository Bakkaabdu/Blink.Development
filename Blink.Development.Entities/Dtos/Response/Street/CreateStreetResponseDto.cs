namespace Blink.Development.Entities.Dtos.Response.Street;

public class CreateStreetResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CityId { get; set; }
    public required decimal DeliveryPrice { get; set; }
    public required decimal BlinkProfit { get; set; }
}
