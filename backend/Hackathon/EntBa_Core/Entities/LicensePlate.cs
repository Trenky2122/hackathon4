using System.ComponentModel.DataAnnotations.Schema;
using EntBa_Core.Entities.Abstractions;
using EntBa_Core.Entities.SystemUsers;

namespace EntBa_Core.Entities
{
    public class LicensePlate : BaseDbo
    {
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public UserDbo? User { get; set; }
        public required string PlateText { get; set; }
        public string? Country { get; set; }
    }
}
