namespace Blink.Development.Entities.Entities;

public enum StatusStep
{
    Pending,
    InProgress,
    Done
}
public class Status
{
    public StatusStep statusStep { get; set; }
    public required ICollection<Order> orders { get; set; }
}

