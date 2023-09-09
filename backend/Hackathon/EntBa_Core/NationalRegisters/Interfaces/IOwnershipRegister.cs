using EntBa_Core.ModelsLogic.NationalRegister;

namespace EntBa_Core.NationalRegisters.Interfaces
{
    public interface IOwnershipRegister
    {
        Task<Ownership> GetOwnershipForPerson(string birthNumber);
    }
}
