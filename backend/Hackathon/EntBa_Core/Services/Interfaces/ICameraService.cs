using EntBa_Core.ModelsLogic;

namespace EntBa_Core.Services.Interfaces
{
    public interface ICameraService
    {
        Task ProcessCameraInput(CameraResult cameraResult);
    }
}
