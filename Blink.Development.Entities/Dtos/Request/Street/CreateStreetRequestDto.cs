namespace Blink.Development.Entities.Dtos.Request.Street;

public class CreateStreetRequestDto
{
    public string Name { get; set; }
    public Guid CityId { get; set; }
    public required decimal DeliveryPrice { get; set; }
    public required decimal BlinkProfit { get; set; }
}
