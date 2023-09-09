using EntBa_Core.Enums;
using EntBa_Core.ModelsLogic.Admin;
using Microsoft.AspNetCore.Mvc;

namespace EntBa_WebBackend.Controllers
{
    [Route("admin")]
    public class AdminController : ControllerBase
    {
        [HttpGet("entranceRequestsBase")]
        public async Task<IList<EntranceRequestBase>> GetEntranceRequestsBase()
        {
            return await Task.FromResult(new List<EntranceRequestBase>
            {
                new()
                {
                    Id = 1,
                    Caption = "Testovací vstup",
                    Date = DateTime.Now,
                    RequesterName = "Ján",
                    RequesterSurname = "Vysoký",
                    RequestState = RequestStateEnum.WaitingForApproval,
                    RequestType = RequestTypeEnum.Resident
                }
            });
        }

    }
}
