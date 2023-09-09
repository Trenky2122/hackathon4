﻿using System.ComponentModel.DataAnnotations.Schema;
using EntBa_Core.Database.Entities.Fines.Abstractions;
using EntBa_Core.Database.Entities.SystemUsers;

namespace EntBa_Core.Database.Entities.Fines;

public class RegisteredUserFineDbo: BaseFineDbo
{
    
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public UserDbo? User { get; set; }
}