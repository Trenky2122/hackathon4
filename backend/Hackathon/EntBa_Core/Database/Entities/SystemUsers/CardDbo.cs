using System.ComponentModel.DataAnnotations.Schema;
using EntBa_Core.Database.Entities.Abstractions;
using EntBa_Core.Enums;
using EntBa_Core.ModelsLogic.Registration;

namespace EntBa_Core.Database.Entities.SystemUsers
{
    public class CardDbo : BaseDbo
    {
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
        public CardTypeEnum CardType { get; set; }
        public required string Number { get; set; }
        public required string Country { get; set; }
    }
}
