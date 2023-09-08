using System.ComponentModel.DataAnnotations.Schema;
using EntBa_Core.Entities.Abstractions;
using EntBa_Core.Entities.Requests;

namespace EntBa_Core.Entities.EntrancePermissions;

public abstract class EntrancePermissionDbo : BaseDbo
{
    public int EntranceRequestId { get; set; }
    [ForeignKey(nameof(EntranceRequestId))]
    public  EntranceRequestDbo? EntranceRequest { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
    public required string LicensePlate { get; set; }
}