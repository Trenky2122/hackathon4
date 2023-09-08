using EntBa_Core.ModelsLogic;

namespace EntBa_Core.Services.Interfaces
{
    public interface ICameraService
    {
        Task ProcessCameraLprEvent(CameraLprEvent cameraLprEvent);
    }
}
