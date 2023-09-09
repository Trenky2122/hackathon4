using EntBa_Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EntBa_WebBackend.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("/recaptcha/{token}/{userAction}")]
        public async Task<bool> RecaptchaVerification(string token, string userAction)
        {
            return await _userService.RecaptchaVerification(token, userAction);
        }
    }
}
