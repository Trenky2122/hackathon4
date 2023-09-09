using EntBa_Core.ModelsLogic;

namespace EntBa_Core.Services.Interfaces
{
    public interface ICarEntranceService
    {
        Task ProcessCameraLprEventEntranceFrontCamera(CameraLprEvent cameraLprEvent);
        Task ProcessCameraLprEventEntranceBackCamera(CameraLprEvent cameraLprEvent);
        Task ProcessCameraLprEventExitFrontCamera(CameraLprEvent cameraLprEvent);
        Task ProcessCameraLprEventExitBackCamera(CameraLprEvent cameraLprEvent);
    }
}
