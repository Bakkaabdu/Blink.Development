namespace Blink.Development.Entities.Entities;

public enum StatusStep
{
    Pending,
    InProgress,
    Done
}
public class Status
{
    public Guid Id { get; set; }
    public StatusStep StatusStep { get; set; }
    public required ICollection<Order> Orders { get; set; }
}

