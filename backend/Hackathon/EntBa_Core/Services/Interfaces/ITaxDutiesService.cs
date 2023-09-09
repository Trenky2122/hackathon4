using EntBa_Core.Database.Entities;
using EntBa_Core.Database.Entities.Requests;

namespace EntBa_Core.Services.Interfaces;

public interface ITaxDutiesService
{
    Task<TaxDutyDbo> CreateTaxDuty(TaxDutyDbo taxDuty);
    decimal CalculateTaxAmountForRequest(EntranceRequestDbo request);
}