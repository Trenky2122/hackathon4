using System.ComponentModel.DataAnnotations.Schema;
using EntBa_Core.Database.Entities.Abstractions;
using EntBa_Core.Database.Entities.Requests;

namespace EntBa_Core.Database.Entities.EntrancePermissions;

public class EntrancePermissionDbo : BaseDbo
{
    public int EntranceRequestId { get; set; }
    [ForeignKey(nameof(EntranceRequestId))]
    public  EntranceRequestDbo? EntranceRequest { get; set; }
    public DateTimeOffset ValidFrom { get; set; }
    public DateTimeOffset ValidTo { get; set; }
    public int LicensePlateId { get; set; }
    [ForeignKey(nameof(LicensePlateId))]
    public LicensePlateDbo? LicensePlateDbo { get; set; }
}