using EntBa_Core.Enums;
using EntBa_Core.ModelsLogic.Registration;
using EntBa_Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EntBa_WebBackend.Controllers
{
    [Route("registration")]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _service;

        public RegistrationController(IRegistrationService service)
        {
            _service = service;
        }

        [HttpGet("verifyLink")]
        public async Task<LinkVerificationResult> VerifyLink(Guid link)
        {
            return await _service.VerifyLink(link);
        }

        [HttpPost("createLink")]
        public async Task<RegistrationResultEnum> CreateRegistrationLink(string email)
        {
            return await _service.CreateRegistrationLink(email);
        }

        [HttpPost("register")]
        public async Task Register([FromBody] User user)
        {
            await _service.Register(user);
        }
    }
}
