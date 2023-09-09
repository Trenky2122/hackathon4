using EntBa_Core.ModelsLogic;
using EntBa_Core.Services.Interfaces;
using HttpMultipartParser;
using Microsoft.AspNetCore.Mvc;

namespace EntBa_Pylon.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CameraController : ControllerBase
    {
        private readonly ICarEntranceService _carEntranceService;

        public CameraController(ICarEntranceService carEntranceService)
        {
            _carEntranceService = carEntranceService;
        }

        [HttpPost]
        public async Task ProcessDtkLprEventFrontCamera()
        {
            var requestParser = await MultipartFormDataParser.ParseAsync(Request.Body).ConfigureAwait(false);
            var cameraEvent = new CameraLprEvent(requestParser);
            await _carEntranceService.ProcessCameraLprEventFrontCamera(cameraEvent);
        }

        [HttpPost]
        public async Task ProcessDtkLprEventBackCamera()
        {
            var requestParser = await MultipartFormDataParser.ParseAsync(Request.Body).ConfigureAwait(false);
            var cameraEvent = new CameraLprEvent(requestParser);
            await _carEntranceService.ProcessCameraLprEventBackCamera(cameraEvent);
        }
    }
    
}