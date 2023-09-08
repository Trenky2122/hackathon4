using System.ComponentModel.DataAnnotations.Schema;
using EntBa_Core.Entities.Abstractions;
using EntBa_Core.Entities.EntrancePermits;
using EntBa_Core.Entities.Requests.Abstractions;

namespace EntBa_Core.Entities;

public class FileDbo: BaseDbo
{
    public required byte[] Content { get; set; }
    public required string FileName { get; set; }
    public int RequestId { get; set; }
    [ForeignKey(nameof(RequestId))]
    public BaseEntranceRequestDbo? Request { get; set; }
}