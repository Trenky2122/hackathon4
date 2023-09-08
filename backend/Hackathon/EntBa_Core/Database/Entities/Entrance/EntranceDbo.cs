using System.ComponentModel.DataAnnotations.Schema;
using EntBa_Core.Database.Entities.Abstractions;

namespace EntBa_Core.Database.Entities.Entrance
{
    public class EntranceDbo : BaseDbo
    {
        public int LicensePlateId { get; set; }
        [ForeignKey(nameof(LicensePlateId))]
        public LicensePlateDbo? LicensePlate { get; set; }
        public DateTimeOffset Entrance { get; set; }
        public DateTimeOffset? Exit { get; set; }
    }
}
