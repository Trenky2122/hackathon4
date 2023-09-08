using EntBa_Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EntBa_WebBackend.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("/recaptcha/{token}/{action}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> RecaptchaVerification(string token, string action)
        {
            ActionResult result;
            try
            {
                result = Ok(await _userService.RecaptchaVerification(token, action));
            }
            catch (HttpRequestException)
            {
                result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            return result;
        }
    }
}
