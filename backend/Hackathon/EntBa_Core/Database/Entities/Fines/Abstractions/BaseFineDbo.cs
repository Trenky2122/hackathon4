using System.ComponentModel.DataAnnotations.Schema;
using EntBa_Core.Database.Entities.Abstractions;
using EntBa_Core.Database.Entities.SystemUsers;

namespace EntBa_Core.Database.Entities.Fines.Abstractions;

public abstract class BaseFineDbo: BaseDbo
{
    public decimal Amount { get; set; }
    public DateTimeOffset DueDate { get; set; }
    public DateTimeOffset CreationDate { get; set; }
    public required string Reason { get; set; }
}