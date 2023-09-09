using EntBa_Core.ModelsLogic.NationalRegister;
using EntBa_Core.NationalRegisters.Interfaces;

namespace EntBa_Core.NationalRegisters.Implementation
{
    public class PhysicalPersonRegister : IPhysicalPersonRegister
    {
        public Task<PhysicalPerson> GetPhysicalPersonByIdCardNumber(string idCardNumber)
        {
            return Task.FromResult(new PhysicalPerson
            {
                Name = "Ján",
                Surname = "Vysoký",
                Address = new Address
                {
                    City = "Bratislava",
                    Number = "14",
                    Street = "Kapitulská"
                },
                BirthNumber = "0214786578",
                IdCardNumber = "FL125784"
            });
        }
    }
}
