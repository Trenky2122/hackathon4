using System.ComponentModel.DataAnnotations.Schema;
using EntBa_Core.Database.Entities.Abstractions;
using EntBa_Core.Database.Entities.Requests;

namespace EntBa_Core.Database.Entities.EntrancePermissions;

public class EntrancePermissionDbo : BaseDbo
{
    public int EntranceRequestId { get; set; }
    [ForeignKey(nameof(EntranceRequestId))]
    public  EntranceRequestDbo? EntranceRequest { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
    public required string LicensePlate { get; set; }
}