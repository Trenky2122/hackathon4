using System.ComponentModel.DataAnnotations.Schema;
using EntBa_Core.Database.Entities.Abstractions;
using EntBa_Core.Database.Entities.SystemUsers;

namespace EntBa_Core.Database.Entities;

public class FineDbo: BaseDbo
{
    public decimal Amount { get; set; }
    public DateTimeOffset DueDate { get; set; }
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public UserDbo? User { get; set; }
    public required string Reason { get; set; }
}