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
        public async Task ProcessDtkLprEventEnterFrontCamera()
        {
            var requestParser = await MultipartFormDataParser.ParseAsync(Request.Body).ConfigureAwait(false);
            var cameraEvent = new CameraLprEvent(requestParser);
            await _carEntranceService.ProcessCameraLprEventEntranceFrontCamera(cameraEvent);
        }

        [HttpPost]
        public async Task ProcessDtkLprEventEnterBackCamera()
        {
            var requestParser = await MultipartFormDataParser.ParseAsync(Request.Body).ConfigureAwait(false);
            var cameraEvent = new CameraLprEvent(requestParser);
            await _carEntranceService.ProcessCameraLprEventEntranceBackCamera(cameraEvent);
        }
        

        [HttpPost]
        public async Task ProcessDtkLprEventExitFrontCamera()
        {
            var requestParser = await MultipartFormDataParser.ParseAsync(Request.Body).ConfigureAwait(false);
            var cameraEvent = new CameraLprEvent(requestParser);
            await _carEntranceService.ProcessCameraLprEventExitFrontCamera(cameraEvent);
        }
        

        [HttpPost]
        public async Task ProcessDtkLprEventExitBackCamera()
        {
            var requestParser = await MultipartFormDataParser.ParseAsync(Request.Body).ConfigureAwait(false);
            var cameraEvent = new CameraLprEvent(requestParser);
            await _carEntranceService.ProcessCameraLprEventExitBackCamera(cameraEvent);
        }
    }
    
}