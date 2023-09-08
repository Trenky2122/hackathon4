using System.ComponentModel.DataAnnotations.Schema;
using EntBa_Core.Entities.Abstractions;
using EntBa_Core.Entities.SystemUsers;

namespace EntBa_Core.Entities.EntrancePermits;

public class RequestDbo: BaseDbo
{
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public UserDbo? UserDbo { get; set; }
}