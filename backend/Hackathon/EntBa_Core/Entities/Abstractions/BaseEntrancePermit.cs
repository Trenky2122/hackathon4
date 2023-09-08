namespace EntBa_Core.Entities.Abstractions;

public abstract class BaseEntrancePermit: BaseDbo
{
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
    public required string LicensePlate { get; set; }
}