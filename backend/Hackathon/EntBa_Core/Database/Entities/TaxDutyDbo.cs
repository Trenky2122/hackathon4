using EntBa_Core.Database.Entities.Abstractions;
using EntBa_Core.Database.Entities.SystemUsers;
using EntBa_Core.Enums;

namespace EntBa_Core.Database.Entities;

public class TaxDutyDbo: BaseDbo
{
    public int UserId { get; set; }
    public UserDbo? User { get; set; }
    public decimal Amount { get; set; }
    public DateTimeOffset ValidFrom { get; set; }
    public bool AppealRequested { get; set; }
    public TaxDutyStateEnum TaxDutyState { get; set; }
    public required string VariableSymbol { get; set; }
}