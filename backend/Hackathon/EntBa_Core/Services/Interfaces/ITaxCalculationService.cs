using EntBa_Core.Database.Entities.Requests;

namespace EntBa_Core.Services.Interfaces;

public interface ITaxCalculationService
{
    decimal CalculateTaxAmountForRequest(EntranceRequestDbo request);
}