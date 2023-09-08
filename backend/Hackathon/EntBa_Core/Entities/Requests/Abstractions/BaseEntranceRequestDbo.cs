using System.ComponentModel.DataAnnotations.Schema;
using EntBa_Core.Entities.Abstractions;
using EntBa_Core.Entities.SystemUsers;

namespace EntBa_Core.Entities.Requests.Abstractions;

public abstract class BaseEntranceRequestDbo: BaseDbo
{
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public UserDbo? UserDbo { get; set; }
    public virtual IList<FileDbo>? Files { get; set; }
    public RequestStateEnum RequestState { get; set; }
}

public enum RequestTypeEnum
{
    Resident,
    Maintenance,
    ParkingPermit,
    SpecialUseOfCommunications,
    HandicappedResidentWorker,
    Wedding,
    Sightseeing,
    PoliceException,
    Supplying,
    ShipSupplying,
    CleaningSecurity,
    SupplyingGreen
}

public enum RequestStateEnum
{
    WaitingForApproval,
    WaitingForCompletionByUser,
    Accepted,
    Rejected
}