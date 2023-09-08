using EntBa_Core.Database;
using EntBa_Core.ModelsLogic.User;
using EntBa_Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace EntBa_Core.Services.Implementation
{
    public class UserService : BaseService, IUserService
    {
        private readonly string _recaptchaSecretKey;

        private HttpClient? _recaptchaClient;
        private HttpClient RecaptchaClient => _recaptchaClient ??= new HttpClient
        {
            BaseAddress = new Uri("https://www.google.com/recaptcha/api/siteverify")
        };

        public UserService(EntBaDbContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            _recaptchaSecretKey = configuration["RecaptchaSecretKey"]!;
        }
        public async Task<bool> RecaptchaVerification(string token, string action)
        {
            var response = await RecaptchaClient.PostAsync($"?secret={_recaptchaSecretKey}&response={token}", null);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var recaptchaResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<RecaptchaResponse>(responseBody);
            var success = recaptchaResponse?.Success ?? false;
            var actionEquals = recaptchaResponse?.Action == action;
            return success && actionEquals;
        }
    }
}
