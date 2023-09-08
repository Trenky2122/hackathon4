using EntBa_Core.Database.Entities.Abstractions;
using EntBa_Core.Database.Entities.SystemUsers;
using EntBa_Core.Enums;

namespace EntBa_Core.Database.Entities;

public class TaxDuty: BaseDbo
{
    public int UserId { get; set; }
    public UserDbo? UserDbo { get; set; }
    public decimal Amount { get; set; }
    public DateTime ValidFrom { get; set; }
    public bool AppealRequested { get; set; }
    public TaxDutyStateEnum TaxDutyState { get; set; }
}