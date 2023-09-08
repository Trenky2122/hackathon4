using EntBa_Core.Services.Interfaces;

namespace EntBa_Core.Services.Implementation;

public class EmailService: IEmailService
{
    public async Task SendEmail(string email, string subject, string body)
    {
        // out of scope
    }
}