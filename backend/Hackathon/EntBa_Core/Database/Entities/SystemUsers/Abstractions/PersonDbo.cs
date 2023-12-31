﻿using EntBa_Core.Database.Entities.Abstractions;

namespace EntBa_Core.Database.Entities.SystemUsers.Abstractions;

public abstract class PersonDbo: BaseDbo
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Email { get; set; }
    public required string PwdHash { get; set; }
    public required string Salt { get; set; }
}
