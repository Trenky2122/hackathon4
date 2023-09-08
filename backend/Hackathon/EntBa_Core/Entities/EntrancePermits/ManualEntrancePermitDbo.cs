using System.ComponentModel.DataAnnotations.Schema;
using EntBa_Core.Entities.EntrancePermits.Abstractions;
using EntBa_Core.Entities.SystemUsers;

namespace EntBa_Core.Entities.EntrancePermits;

public class ManualEntrancePermitDbo: BaseEntrancePermitDbo
{
    public int AdministratorId { get; set; }
    [ForeignKey(nameof(AdministratorId))]
    public AdministratorDbo? Administrator { get; set; }
}