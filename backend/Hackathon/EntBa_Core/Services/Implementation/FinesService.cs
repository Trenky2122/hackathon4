using EntBa_Core.Database;
using EntBa_Core.Database.Entities;
using EntBa_Core.Database.Entities.Fines;
using EntBa_Core.Database.Entities.Fines.Abstractions;
using EntBa_Core.Services.Interfaces;

namespace EntBa_Core.Services.Implementation;

public class FinesService: BaseService, IFinesService
{
    private readonly IEmailService _emailService;
    public FinesService(EntBaDbContext dbContext, IEmailService emailService): base(dbContext)
    {
        _emailService = emailService;
    }

    public async Task<BaseFineDbo> CreateUserFine(RegisteredUserFineDbo userFine)
    {
        var fineTask = DbContext.AddAsync(userFine);
        var user = await DbContext.Users.FindAsync(userFine.UserId);
        var emailTask = _emailService.SendEmail(user.Email, "Bola Vám udelená pokuta.",
            "V zmysle zákona na základe priestupku...");
        await emailTask;
        await DbContext.SaveChangesAsync();
        return (await fineTask).Entity;
    }
    
    public async Task<BaseFineDbo> CreateNonUserFine(NonUserFineDbo fine)
    {
        var fineTask = DbContext.AddAsync(fine);
        string adminMail = "";
        var emailTask = _emailService.SendEmail(adminMail, "Neoprávnený vstup vozidla do oblasti starého mesta.",
            "Treba poslať pokutu poštou.");
        await emailTask;
        await DbContext.SaveChangesAsync();
        return (await fineTask).Entity;
    }
}