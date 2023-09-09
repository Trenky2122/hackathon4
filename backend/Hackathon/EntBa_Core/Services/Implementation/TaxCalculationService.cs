using EntBa_Core.Database.Entities.Requests;
using EntBa_Core.Enums;
using EntBa_Core.Services.Interfaces;

namespace EntBa_Core.Services.Implementation;

public class TaxCalculationService: ITaxCalculationService
{
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
                return 5;
            case RequestTypeEnum.ParkingPermit:
            case RequestTypeEnum.SupplyingGreen:
                return 1;
            case RequestTypeEnum.SpecialUseOfCommunications:
            case RequestTypeEnum.PoliceException:
            case RequestTypeEnum.Sightseeing:
                return 15;
            case RequestTypeEnum.Wedding:
                return 30;
            case RequestTypeEnum.Supplying:
                case RequestTypeEnum.CleaningSecurity:
                return 3;
            case RequestTypeEnum.ShipSupplying:
                return 6;
            default:
                throw new NotImplementedException($"Tax for request type {request.RequestType} not implemented.");
        }
    }
}