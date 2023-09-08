using System.ComponentModel.DataAnnotations.Schema;
using EntBa_Core.Database.Entities.Abstractions;

namespace EntBa_Core.Database.Entities.Entrance
{
    public class EntranceDbo : BaseDbo
    {
        public int LicensePlateId { get; set; }
        [ForeignKey(nameof(LicensePlateId))]
        public LicensePlate? LicensePlate { get; set; }
        public DateTime Entrance { get; set; }
        public DateTime Exit { get; set; }
    }
}
