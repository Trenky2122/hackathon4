using System.Security.Permissions;
using EntBa_Core.Database;
using EntBa_Core.ModelsLogic;
using EntBa_Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntBa_Core.Services.Implementation
{
    public class CameraService : BaseService, ICameraService
    {
        private readonly IPylonService _pylonService;
        public CameraService(EntBaDbContext dbContext, IPylonService pylonService) : base(dbContext)
        {
            _pylonService = pylonService;
        }
        
        public async Task ProcessCameraLprEvent(CameraLprEvent cameraLprEvent)
        {
            var licensePlate = await DbContext.LicensePlates.FirstOrDefaultAsync(
                plate => plate.PlateText == cameraLprEvent.LicensePlate &&
                         plate.Country == cameraLprEvent.LicensePlateCountryCode);
            if (licensePlate is null)
                return; // unknown plate, gate not opened
            var entrancePermit = await DbContext.EntrancePermissions.FirstOrDefaultAsync(permit =>
                permit.LicensePlateId == licensePlate.Id
                && DateTimeOffset.UtcNow > permit.ValidFrom && DateTimeOffset.UtcNow < permit.ValidTo);
            if (entrancePermit is not null)
                await _pylonService.Open();
        }
    }
}
