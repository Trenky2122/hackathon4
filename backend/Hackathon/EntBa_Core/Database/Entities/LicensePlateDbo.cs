using System.ComponentModel.DataAnnotations.Schema;
using EntBa_Core.Database.Entities.Abstractions;
using EntBa_Core.Database.Entities.SystemUsers;

namespace EntBa_Core.Database.Entities
{
    public class LicensePlateDbo : BaseDbo
    {
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public UserDbo? User { get; set; }
        public required string PlateText { get; set; }
        public string? Country { get; set; }
    }
}
