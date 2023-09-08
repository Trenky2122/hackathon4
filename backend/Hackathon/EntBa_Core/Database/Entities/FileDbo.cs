using System.ComponentModel.DataAnnotations.Schema;
using EntBa_Core.Database.Entities.Abstractions;
using EntBa_Core.Database.Entities.Requests;

namespace EntBa_Core.Database.Entities;

public class FileDbo: BaseDbo
{
    public required byte[] Content { get; set; }
    public required string FileName { get; set; }
    public int RequestId { get; set; }
    [ForeignKey(nameof(RequestId))]
    public EntranceRequestDbo? Request { get; set; }
}