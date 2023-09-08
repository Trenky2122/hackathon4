using System.ComponentModel.DataAnnotations;

namespace EntBa_Core.Entities;

public abstract class BaseDbo
{
    [Key]
    public int Id { get; set; }
}