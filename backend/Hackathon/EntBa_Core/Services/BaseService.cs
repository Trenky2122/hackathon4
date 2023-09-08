using EntBa_Core.DbContext;

namespace EntBa_Core.Services
{
    public abstract class BaseService
    {
        protected readonly DatabaseContext DbContext;
        protected BaseService(DatabaseContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
