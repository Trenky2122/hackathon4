using EntBa_Core.ModelsLogic.NationalRegister;

namespace EntBa_Core.NationalRegisters.Interfaces
{
    public interface ILicensePlateRegister
    {
        Task<LicensePlate> GetLicensePlate(string licensePlateText);
    }
}
