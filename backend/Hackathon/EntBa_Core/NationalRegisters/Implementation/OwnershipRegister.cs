using EntBa_Core.ModelsLogic.NationalRegister;
using EntBa_Core.NationalRegisters.Interfaces;

namespace EntBa_Core.NationalRegisters.Implementation
{
    public class OwnershipRegister : IOwnershipRegister
    {
        public Task<Ownership> GetOwnershipForPerson(string birthNumber)
        {
            return Task.FromResult(new Ownership
            {
                BirthNumber = "0214786578",
                Locations = new List<Location>
                {
                    new()
                    {
                        City = "Bratislava",
                        Parcel = "145/7"
                    }
                }
            });
        }
    }
}
