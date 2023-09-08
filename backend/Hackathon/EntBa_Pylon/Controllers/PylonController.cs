using EntBa_Pylon.Services;
using Microsoft.AspNetCore.Mvc;

namespace EntBa_Pylon.Controllers
{
    [ApiController]
    [Route("open")]
    public class PylonController : ControllerBase
    {
        
        private readonly ILogger<PylonController> _logger;
        private readonly IPylonService _service;

        public PylonController(ILogger<PylonController> logger)
        {
            _logger = logger;
        }

        [HttpPost("open")]
        public async Task<ActionResult> Open()
        {
            return Ok();
        }

        [HttpPost("close")]
        public async Task<ActionResult> Close()
        {
            return Ok();
        }
    }
}