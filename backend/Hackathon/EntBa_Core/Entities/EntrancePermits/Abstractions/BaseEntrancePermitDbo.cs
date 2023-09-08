using EntBa_Core.Entities.Abstractions;

namespace EntBa_Core.Entities.EntrancePermits.Abstractions;

public abstract class BaseEntrancePermitDbo: BaseDbo
{
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
    public required string LicensePlate { get; set; }
}