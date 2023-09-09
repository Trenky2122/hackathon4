using EntBa_Core.Database.Entities.Fines;
using EntBa_Core.Database.Entities.Fines.Abstractions;

namespace EntBa_Core.Services.Interfaces;

public interface IFinesService
{
    Task<BaseFineDbo> CreateUserFine(RegisteredUserFineDbo userFine);
}