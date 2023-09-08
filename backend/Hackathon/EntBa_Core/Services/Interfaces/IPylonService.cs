using EntBa_Core.Enums;

namespace EntBa_Core.Services.Interfaces
{
    public interface IPylonService
    {
        Task Open();
        Task Close();
        Task<PylonStateEnum> GetState();
    }
}
