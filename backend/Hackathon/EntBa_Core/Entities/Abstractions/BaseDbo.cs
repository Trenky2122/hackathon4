using System.ComponentModel.DataAnnotations;

namespace EntBa_Core.Entities.Abstractions;

public abstract class BaseDbo
{
    [Key]
    public int Id { get; set; }
}