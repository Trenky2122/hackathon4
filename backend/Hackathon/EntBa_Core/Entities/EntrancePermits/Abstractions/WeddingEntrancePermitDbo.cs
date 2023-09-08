using System.ComponentModel.DataAnnotations.Schema;
using EntBa_Core.Entities.SystemUsers;

namespace EntBa_Core.Entities.EntrancePermits.Abstractions;

public class WeddingEntrancePermitDbo: BaseEntrancePermitDbo
{
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public UserDbo? User { get; set; }
}