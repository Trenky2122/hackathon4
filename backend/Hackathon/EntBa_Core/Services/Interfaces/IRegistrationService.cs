using EntBa_Core.Enums;
using EntBa_Core.ModelsLogic.Registration;

namespace EntBa_Core.Services.Interfaces
{
    public interface IRegistrationService
    {
        Task<RegistrationResultEnum> CreateRegistrationLink(string email);
        Task<LinkVerificationResult> VerifyLink(Guid link);
        Task Register(User user);
    }
}
