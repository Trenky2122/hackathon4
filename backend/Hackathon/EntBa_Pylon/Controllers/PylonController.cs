using EntBa_Core.Enums;
using EntBa_Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EntBa_Pylon.Controllers
{
    [ApiController]
    [Route("open")]
    public class PylonController : ControllerBase
    {
        
        private readonly IPylonService _service;

        public PylonController(IPylonService service)
        {
            _service = service;
        }

        [HttpPost("open")]
        public async Task Open()
        {
            await _service.Open();
        }

        [HttpPost("close")]
        public async Task Close()
        {
            await _service.Close();
        }

        [HttpGet("state")]
        public async Task<PylonStateEnum> GetState()
        {
            return await _service.GetState();
        }
    }
}