using System.Security.Permissions;
using EntBa_Core.Database;
using EntBa_Core.Database.Entities;
using EntBa_Core.Database.Entities.Entrance;
using EntBa_Core.Database.Entities.EntrancePermissions;
using EntBa_Core.ModelsLogic;
using EntBa_Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntBa_Core.Services.Implementation
{
    public class CarEntranceService : BaseService, ICarEntranceService
    {
        private readonly IPylonService _pylonService;
        private readonly ITaxCalculationService _taxCalculationService;
        private readonly IEmailService _emailService;
        public CarEntranceService(EntBaDbContext dbContext, 
            IPylonService pylonService, 
            ITaxCalculationService taxCalculationService,
            IEmailService emailService) : base(dbContext)
        {
            _pylonService = pylonService;
            _taxCalculationService = taxCalculationService;
            _emailService = emailService;
        }

        public async Task ProcessCameraLprEventFrontCamera(CameraLprEvent cameraLprEvent)
        {
            var entrancePermit = await FindPermissionForCameraEvent(cameraLprEvent);
            if (entrancePermit is null)
                return;
            Task pylonTask = _pylonService.Open();
            await DbContext.AddAsync(new EntranceDbo()
            {
                EntranceCameraFront = DateTimeOffset.UtcNow,
                LicensePlateId = entrancePermit.LicensePlateId,
                PermissionId = entrancePermit.Id
            });
            await DbContext.SaveChangesAsync();
            await pylonTask;
        }

        public async Task ProcessCameraLprEventBackCamera(CameraLprEvent cameraLprEvent)
        {
            var licensePlate = await DbContext.LicensePlates.FirstOrDefaultAsync(
                plate => plate.PlateText == cameraLprEvent.LicensePlate &&
                         plate.Country == cameraLprEvent.LicensePlateCountryCode);
            if (licensePlate is null)
            {
                // TODO: Domysliet
                return;
            }
            var entranceFromFront = await DbContext.Entrances
                .Include(ent => ent.Permission)
                .ThenInclude(perm => perm.EntranceRequest)
                .FirstOrDefaultAsync(entrance => 
                entrance.EntranceCameraFront.AddMinutes(-2) < DateTimeOffset.UtcNow 
                && entrance.LicensePlateId == licensePlate.Id);
            EntrancePermissionDbo? permission;
            if (entranceFromFront is null)
            {
                permission = await FindPermissionForCameraEvent(cameraLprEvent);
                if (permission is null)
                {
                    // notifikacia uradov s dokazovym materialom
                    // vyrubenie pokuty
                    return;
                }
                await DbContext.Entrances.AddAsync(new EntranceDbo()
                {
                    EntranceCameraFront = DateTimeOffset.UtcNow,
                    EntranceCameraBack = DateTimeOffset.UtcNow,
                    LicensePlateId = licensePlate.Id,
                    PermissionId = permission.Id
                });
            }
            else
            {
                entranceFromFront.EntranceCameraBack = DateTimeOffset.UtcNow;
                permission = entranceFromFront.Permission!;
            }
            
            await DbContext.TaxDuties.AddAsync(new TaxDutyDbo()
            {
                UserId = permission.EntranceRequest!.UserId,
                ValidFrom = DateTimeOffset.UtcNow,
                Amount = _taxCalculationService.CalculateTaxAmountForRequest(permission.EntranceRequest)
            });
            await DbContext.SaveChangesAsync();
        }
        
        private async Task<EntrancePermissionDbo?> FindPermissionForCameraEvent(CameraLprEvent cameraEvent)
        {
            var licensePlate = await DbContext.LicensePlates.FirstOrDefaultAsync(
                plate => plate.PlateText == cameraEvent.LicensePlate &&
                         plate.Country == cameraEvent.LicensePlateCountryCode);
            if (licensePlate is null)
                return null; // unknown plate, gate not opened
            return await DbContext.EntrancePermissions
                .Include(permit => permit.EntranceRequest)
                .FirstOrDefaultAsync(permit =>
                permit.LicensePlateId == licensePlate.Id
                && DateTimeOffset.UtcNow > permit.ValidFrom && DateTimeOffset.UtcNow < permit.ValidTo);
        }
    }
}
