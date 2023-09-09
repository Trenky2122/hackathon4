using System.ComponentModel.DataAnnotations.Schema;
using EntBa_Core.Database.Entities.Abstractions;
using EntBa_Core.Database.Entities.EntrancePermissions;

namespace EntBa_Core.Database.Entities.Entrance
{
    public class EntranceDbo : BaseDbo
    {
        public int LicensePlateId { get; set; }
        [ForeignKey(nameof(LicensePlateId))]
        public LicensePlateDbo? LicensePlate { get; set; }
        public DateTimeOffset EntranceCameraFront { get; set; }
        public DateTimeOffset? EntranceCameraBack { get; set; }
        public DateTimeOffset? ExitCameraFront { get; set; }
        public DateTimeOffset? ExitCameraBack { get; set; }
        public int PermissionId { get; set; }
        [ForeignKey(nameof(PermissionId))]
        public EntrancePermissionDbo? Permission { get; set; }
    }
}
