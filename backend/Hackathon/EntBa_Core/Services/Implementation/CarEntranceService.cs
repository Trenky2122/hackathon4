using System.Security.Permissions;
using EntBa_Core.Database;
using EntBa_Core.Database.Entities;
using EntBa_Core.Database.Entities.Entrance;
using EntBa_Core.Database.Entities.EntrancePermissions;
using EntBa_Core.Database.Entities.Fines;
using EntBa_Core.Database.Entities.Fines.Abstractions;
using EntBa_Core.ModelsLogic;
using EntBa_Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntBa_Core.Services.Implementation
{
    public class CarEntranceService : BaseService, ICarEntranceService
    {
        private readonly IPylonService _pylonService;
        private readonly TaxDutiesesService _taxDutiesesService;
        private readonly FinesService _finesService;
        public CarEntranceService(EntBaDbContext dbContext, 
            IPylonService pylonService, 
            IEmailService emailService, FinesService finesService, TaxDutiesesService taxDutiesesService) : base(dbContext)
        {
            _pylonService = pylonService;
            _finesService = finesService;
            _taxDutiesesService = taxDutiesesService;
        }

        public async Task ProcessCameraLprEventEntranceFrontCamera(CameraLprEvent cameraLprEvent)
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

        public async Task ProcessCameraLprEventEntranceBackCamera(CameraLprEvent cameraLprEvent)
        {
            var pylonTask = _pylonService.Close();
            var licensePlate = await DbContext.LicensePlates.FirstOrDefaultAsync(
                plate => plate.PlateText == cameraLprEvent.LicensePlate &&
                         plate.Country == cameraLprEvent.LicensePlateCountryCode);
            if (licensePlate is null)
            {
                await _finesService.CreateNonUserFine(new NonUserFineDbo()
                {
                    DueDate = DateTimeOffset.UtcNow.AddDays(15),
                    CreationDate = DateTimeOffset.UtcNow,
                    LicensePlate = cameraLprEvent.LicensePlate,
                    LicensePlateCountryCode = cameraLprEvent.LicensePlateCountryCode,
                    Amount = 123456,
                    Reason = "Neoprávnený vstup ..."
                });
                return;
            }
            var entranceFromFront = await DbContext.Entrances
                .Include(ent => ent.Permission)
                .ThenInclude(perm => perm.EntranceRequest)
                .FirstOrDefaultAsync(entrance => 
                entrance.ExitCameraBack != null 
                && entrance.LicensePlateId == licensePlate.Id);
            EntrancePermissionDbo? permission;
            if (entranceFromFront is null)
            {
                permission = await FindPermissionForCameraEvent(cameraLprEvent);
                if (permission is null)
                {
                    // notifikacia uradov s dokazovym materialom
                    // vyrubenie pokuty
                    await _finesService.CreateUserFine(new RegisteredUserFineDbo()
                    {
                        Reason = "Neoprávnený vstup",
                        DueDate = DateTimeOffset.UtcNow.AddDays(15),
                        CreationDate = DateTimeOffset.UtcNow,
                        Amount = 123456,
                        UserId = licensePlate.UserId
                    });
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
            
            await _taxDutiesesService.CreateTaxDuty(new TaxDutyDbo()
            {
                UserId = permission.EntranceRequest!.UserId,
                ValidFrom = DateTimeOffset.UtcNow,
                Amount = _taxDutiesesService.CalculateTaxAmountForRequest(permission.EntranceRequest)
            });
            await DbContext.SaveChangesAsync();
            await pylonTask;
        }

        public async Task ProcessCameraLprEventExitFrontCamera(CameraLprEvent cameraLprEvent)
        {
            var pylonTask = _pylonService.Open();
            var licensePlate = await DbContext.LicensePlates.FirstOrDefaultAsync(
                plate => plate.PlateText == cameraLprEvent.LicensePlate &&
                         plate.Country == cameraLprEvent.LicensePlateCountryCode);
            if (licensePlate is null)
            {
                await _finesService.CreateNonUserFine(new NonUserFineDbo()
                {
                    DueDate = DateTimeOffset.UtcNow.AddDays(15),
                    CreationDate = DateTimeOffset.UtcNow,
                    LicensePlate = cameraLprEvent.LicensePlate,
                    LicensePlateCountryCode = cameraLprEvent.LicensePlateCountryCode,
                    Amount = 123456,
                    Reason = "Neoprávnený vstup ..."
                });
                return;
            }
            var entranceOriginal = await DbContext.Entrances
                .Include(ent => ent.Permission)
                .ThenInclude(perm => perm.EntranceRequest)
                .FirstOrDefaultAsync(entrance => 
                entrance.ExitCameraBack != null  
                && entrance.LicensePlateId == licensePlate.Id);
            EntrancePermissionDbo? permission;
            if (entranceOriginal is null)
            {
                permission = await FindPermissionForCameraEvent(cameraLprEvent);
                if (permission is null)
                {
                    // notifikacia uradov s dokazovym materialom
                    // vyrubenie pokuty
                    await _finesService.CreateUserFine(new RegisteredUserFineDbo()
                    {
                        Reason = "Neoprávnený vstup",
                        DueDate = DateTimeOffset.UtcNow.AddDays(15),
                        CreationDate = DateTimeOffset.UtcNow,
                        Amount = 123456,
                        UserId = licensePlate.UserId
                    });
                    return;
                }
                await DbContext.Entrances.AddAsync(new EntranceDbo()
                {
                    EntranceCameraFront = DateTimeOffset.UtcNow,
                    EntranceCameraBack = DateTimeOffset.UtcNow,
                    ExitCameraFront = DateTimeOffset.UtcNow,
                    LicensePlateId = licensePlate.Id,
                    PermissionId = permission.Id
                });
            }
            else
            {
                entranceOriginal.EntranceCameraFront = DateTimeOffset.UtcNow;
                permission = entranceOriginal.Permission!;
            }

            if (permission.ValidTo > DateTimeOffset.UtcNow)
                await _finesService.CreateUserFine(new RegisteredUserFineDbo()
                {
                    Reason = "Neopravneny pohyb ...",
                    DueDate = DateTimeOffset.UtcNow.AddDays(15),
                    CreationDate = DateTimeOffset.UtcNow,
                    UserId = permission.EntranceRequest.UserId,
                    Amount = 1234,
                });
            await DbContext.SaveChangesAsync();
            await pylonTask;
        }
        
        public async Task ProcessCameraLprEventExitBackCamera(CameraLprEvent cameraLprEvent)
        {
            var pylonTask = _pylonService.Close();
            var licensePlate = await DbContext.LicensePlates.FirstOrDefaultAsync(
                plate => plate.PlateText == cameraLprEvent.LicensePlate &&
                         plate.Country == cameraLprEvent.LicensePlateCountryCode);
            if (licensePlate is null)
            {
                await _finesService.CreateNonUserFine(new NonUserFineDbo()
                {
                    DueDate = DateTimeOffset.UtcNow.AddDays(15),
                    CreationDate = DateTimeOffset.UtcNow,
                    LicensePlate = cameraLprEvent.LicensePlate,
                    LicensePlateCountryCode = cameraLprEvent.LicensePlateCountryCode,
                    Amount = 123456,
                    Reason = "Neoprávnený vstup ..."
                });
                return;
            }
            var entranceOriginal = await DbContext.Entrances
                .Include(ent => ent.Permission)
                .ThenInclude(perm => perm.EntranceRequest)
                .FirstOrDefaultAsync(entrance => 
                entrance.ExitCameraBack != null  
                && entrance.LicensePlateId == licensePlate.Id);
            EntrancePermissionDbo? permission;
            if (entranceOriginal is null)
            {
                permission = await FindPermissionForCameraEvent(cameraLprEvent);
                if (permission is null)
                {
                    // notifikacia uradov s dokazovym materialom
                    // vyrubenie pokuty
                    await _finesService.CreateUserFine(new RegisteredUserFineDbo()
                    {
                        Reason = "Neoprávnený vstup",
                        DueDate = DateTimeOffset.UtcNow.AddDays(15),
                        CreationDate = DateTimeOffset.UtcNow,
                        Amount = 123456,
                        UserId = licensePlate.UserId
                    });
                    return;
                }
                await DbContext.Entrances.AddAsync(new EntranceDbo()
                {
                    EntranceCameraFront = DateTimeOffset.UtcNow,
                    EntranceCameraBack = DateTimeOffset.UtcNow,
                    ExitCameraFront = DateTimeOffset.UtcNow,
                    ExitCameraBack = DateTimeOffset.UtcNow,
                    LicensePlateId = licensePlate.Id,
                    PermissionId = permission.Id
                });
            }
            else
            {
                entranceOriginal.ExitCameraBack = DateTimeOffset.UtcNow;
                permission = entranceOriginal.Permission!;
            }

            if (permission.ValidTo > DateTimeOffset.UtcNow)
                await _finesService.CreateUserFine(new RegisteredUserFineDbo()
                {
                    Reason = "Neopravneny pohyb ...",
                    DueDate = DateTimeOffset.UtcNow.AddDays(15),
                    CreationDate = DateTimeOffset.UtcNow,
                    UserId = permission.EntranceRequest.UserId,
                    Amount = 1234,
                });
            await DbContext.SaveChangesAsync();
            await pylonTask;
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
