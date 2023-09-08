using EntBa_Core.Database;

namespace EntBa_Core.Services
{
    public abstract class BaseService
    {
        protected readonly EntBaDbContext DbContext;
        protected BaseService(EntBaDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
