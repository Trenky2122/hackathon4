using System.ComponentModel.DataAnnotations.Schema;
using EntBa_Core.Database.Entities.SystemUsers.Abstractions;

namespace EntBa_Core.Database.Entities.SystemUsers;

public class UserDbo: PersonDbo
{
    public virtual IList<CardDbo>? IdCards { get; set; }
    public bool Verified { get; set; }
}