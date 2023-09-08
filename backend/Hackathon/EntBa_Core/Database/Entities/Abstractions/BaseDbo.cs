using System.ComponentModel.DataAnnotations;

namespace EntBa_Core.Database.Entities.Abstractions;

public abstract class BaseDbo
{
    [Key]
    public int Id { get; set; }
}