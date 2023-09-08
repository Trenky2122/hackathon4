using EntBa_Core.Entities.Abstractions;

namespace EntBa_Core.Entities.SystemUsers
{
    public class UserLinkDbo : BaseDbo
    {
        public required string Email { get; set; }
        public required Guid LinkGiud { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
