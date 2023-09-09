using EntBa_Core.ModelsLogic.NationalRegister;
using EntBa_Core.NationalRegisters.Interfaces;

namespace EntBa_Core.NationalRegisters.Implementation
{
    public class LicensePlateRegister : ILicensePlateRegister
    {
        public Task<LicensePlate> GetLicensePlate(string licensePlateText)
        {
            return Task.FromResult(new LicensePlate
            {
                BirthNumber = "0214786578",
                LicensePlateText = "MA524PL",
                OwnerName = "Ján",
                OwnerSurname = "Vysoký"
            });
        }
    }
}
