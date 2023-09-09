using EntBa_Core.ModelsLogic.NationalRegister;

namespace EntBa_Core.NationalRegisters.Interfaces
{
    public interface IPhysicalPersonRegister
    {
        Task<PhysicalPerson> GetPhysicalPersonByIdCardNumber(string idCardNumber);
    }
}
