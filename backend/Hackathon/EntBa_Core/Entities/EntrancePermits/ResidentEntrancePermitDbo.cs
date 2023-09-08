using System.ComponentModel.DataAnnotations.Schema;
using EntBa_Core.Entities.EntrancePermits.Abstractions;
using EntBa_Core.Entities.SystemUsers;

namespace EntBa_Core.Entities.EntrancePermits;

public class ResidentEntrancePermitDbo: BaseEntrancePermitDbo
{
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public UserDbo? User { get; set; }
}