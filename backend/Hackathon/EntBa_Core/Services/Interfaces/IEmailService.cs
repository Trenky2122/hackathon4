namespace EntBa_Core.Services.Interfaces;

public interface IEmailService
{
    Task SendEmail(string email, string subject, string body);
}