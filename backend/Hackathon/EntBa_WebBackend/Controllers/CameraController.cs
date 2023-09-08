using EntBa_Core.ModelsLogic;
using EntBa_Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EntBa_WebBackend.Controllers
{
    [ApiController]
    [Route("camera")]
    public class CameraController : ControllerBase
    {
        private readonly ICameraService _cameraService;

        public CameraController(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        [HttpPost("process")]
        public async Task ProcessCameraInput(CameraResult cameraResult)
        {
            await _cameraService.ProcessCameraInput(cameraResult);
        }
        
    }
}