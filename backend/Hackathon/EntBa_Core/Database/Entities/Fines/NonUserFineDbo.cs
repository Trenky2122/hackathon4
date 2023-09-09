using EntBa_Core.Database.Entities.Fines.Abstractions;

namespace EntBa_Core.Database.Entities.Fines;

public class NonUserFineDbo: BaseFineDbo
{
    public required string LicensePlate { get; set; }
    public required string LicensePlateCountryCode { get; set; }
}