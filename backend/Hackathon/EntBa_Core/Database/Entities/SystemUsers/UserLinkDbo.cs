﻿using EntBa_Core.Database.Entities.Abstractions;

namespace EntBa_Core.Database.Entities.SystemUsers
{
    public class UserLinkDbo : BaseDbo
    {
        public required string Email { get; set; }
        public required Guid LinkGiud { get; set; }
        public DateTimeOffset CreationTime { get; set; }
    }
}
