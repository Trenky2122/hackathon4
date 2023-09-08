using System.ComponentModel.DataAnnotations.Schema;
using EntBa_Core.Entities.Abstractions;
using EntBa_Core.Entities.SystemUsers;
using EntBa_Core.Enums;

namespace EntBa_Core.Entities.Requests;

public class EntranceRequestDbo : BaseDbo
{
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public UserDbo? UserDbo { get; set; }
    public IList<FileDbo>? Files { get; set; }
    public RequestTypeEnum RequestType { get; set; }
    public RequestStateEnum RequestState { get; set; }
    public string? AllowedPlaces { get; set; }
}