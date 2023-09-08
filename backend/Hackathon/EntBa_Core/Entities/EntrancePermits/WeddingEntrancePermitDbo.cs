using System.ComponentModel.DataAnnotations.Schema;
using EntBa_Core.Entities.EntrancePermits.Abstractions;
using EntBa_Core.Entities.Requests;
using EntBa_Core.Entities.SystemUsers;

namespace EntBa_Core.Entities.EntrancePermits;

public class WeddingEntrancePermitDbo: BaseEntrancePermitDbo
{
    public int RequestId { get; set; }
    [ForeignKey(nameof(RequestId))]
    public WeddingEntranceEntranceRequestDbo? Wedding { get; set; }
}