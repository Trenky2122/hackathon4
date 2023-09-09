using EntBa_Core.Database;
using EntBa_Core.Database.Entities;
using EntBa_Core.Database.Entities.Requests;
using EntBa_Core.Enums;
using EntBa_Core.Services.Interfaces;

namespace EntBa_Core.Services.Implementation;

public class TaxDutiesesService: BaseService, ITaxDutiesService
{
    private readonly IEmailService _emailService;
    public TaxDutiesesService(EntBaDbContext dbContext, IEmailService emailService): base(dbContext)
    {
        _emailService = emailService;
    }

    public async Task<TaxDutyDbo> CreateTaxDuty(TaxDutyDbo taxDuty)
    {
        var taxDutyTask = DbContext.AddAsync(taxDuty);
        var user = await DbContext.Users.FindAsync(taxDuty.UserId);
        var emailTask = _emailService.SendEmail(user.Email, "Oznámenie o vzniku daňovej povinnosti.",
            "V zmysle zákona na základe vstupu...");
        await emailTask;
        await DbContext.SaveChangesAsync();
        return (await taxDutyTask).Entity;
    }
    
    public decimal CalculateTaxAmountForRequest(EntranceRequestDbo request)
    {
        if (request.IsYearly)
        {
            switch (request.RequestType)
            {
                case RequestTypeEnum.Resident:
                case RequestTypeEnum.HandicappedResidentWorker:
                    return 10;
                case RequestTypeEnum.ParkingPermit:
                    return 365;
                case RequestTypeEnum.Sightseeing:
                    return 6000;
                case RequestTypeEnum.PoliceException:
                    return 3900;
                case RequestTypeEnum.Supplying:
                    return 1400;
                case RequestTypeEnum.ShipSupplying:
                    return 2000;
                case RequestTypeEnum.SupplyingGreen:
                    return 200;
                case RequestTypeEnum.CleaningSecurity:
                    return 702;
                default:
                    throw new NotSupportedException(
                        $"Yearly permit not supported for request type {request.RequestType}");
            }
        }

        switch (request.RequestType)
        {
            case RequestTypeEnum.Resident:
            case RequestTypeEnum.HandicappedResidentWorker:
                return 0.1m;
            case RequestTypeEnum.Maintenance:
            case RequestTypeEnum.Supplying:
                return 5;
            case RequestTypeEnum.ParkingPermit:
            case RequestTypeEnum.SupplyingGreen:
                return 1;
            case RequestTypeEnum.SpecialUseOfCommunications:
            case RequestTypeEnum.PoliceException:
                return 15;
            case RequestTypeEnum.Wedding:
            case RequestTypeEnum.Sightseeing:
                return 30;
            case RequestTypeEnum.CleaningSecurity:
                return 3;
            case RequestTypeEnum.ShipSupplying:
                return 9;
            default:
                throw new NotImplementedException($"Tax for request type {request.RequestType} not implemented.");
        }
    }
}