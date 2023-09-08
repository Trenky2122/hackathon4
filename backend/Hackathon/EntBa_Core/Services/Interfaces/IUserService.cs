namespace EntBa_Core.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> RecaptchaVerification(string token, string action);
    }
}
