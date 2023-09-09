using EntBa_Core.ModelsLogic;

namespace EntBa_Core.Services.Interfaces
{
    public interface ICarEntranceService
    {
        Task ProcessCameraLprEventFrontCamera(CameraLprEvent cameraLprEvent);
        Task ProcessCameraLprEventBackCamera(CameraLprEvent cameraLprEvent);
    }
}
