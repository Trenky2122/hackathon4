using EntBa_Core.Database;
using EntBa_Core.Enums;
using EntBa_Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntBa_Core.Services.Implementation;

public class ReminderService: BaseService
{
    private readonly IEmailService _emailService;
    public ReminderService(EntBaDbContext dbContext, IEmailService emailService) : base(dbContext)
    {
        _emailService = emailService;
    }
    
    public async Task RemindTaxDuties()
    {
        var activeTaxDutiesCloseToEnd = await DbContext.TaxDuties.Include(duty => duty.User).Where(duty =>
            duty.TaxDutyState == TaxDutyStateEnum.Active
            && (duty.ValidFrom.AddDays(Constants.TAX_TIME_TO_PAY_DAYS) > DateTime.Now.AddDays(-1 * Constants.TAX_NOTIFICATION_BEFORE_DAYS)
            || duty.AppealRequested && duty.ValidFrom.AddDays(Constants.TAX_TIME_TO_PAY_DAYS + Constants.TAX_TIME_APPEAL_DAYS) > DateTime.Now.AddDays(-1 * Constants.TAX_NOTIFICATION_BEFORE_DAYS)))
            .ToListAsync();
        foreach (var duty in activeTaxDutiesCloseToEnd)
        {
            await _emailService.SendEmail(duty.User!.Email, "Upozornenie na blížiace sa vypršanie splatnosti dane.",
                "Splatnosť dane onedlho končí, v prípade nezaplatenia hrozí pokuta. Zaplatiť sa sá takto.");
        }
    }
}