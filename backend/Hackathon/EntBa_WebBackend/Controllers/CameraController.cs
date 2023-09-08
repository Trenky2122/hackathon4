using EntBa_Core.ModelsLogic;
using EntBa_Core.Services.Interfaces;
using HttpMultipartParser;
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

        [HttpPost("processDtkLprEvent")]
        [Consumes("multipart/form-data")]
        public async Task ProcessDtkLprEvent()
        {
            var request = await MultipartFormDataParser.ParseAsync(Request.Body).ConfigureAwait(false);
            var requestText = request.GetParameterValues("text");
            var cameraResult = new CameraLprEvent();
            await _cameraService.ProcessCameraInput(cameraResult);
        }
    }
    
}