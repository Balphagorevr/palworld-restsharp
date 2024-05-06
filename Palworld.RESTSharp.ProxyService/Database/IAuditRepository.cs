using Palworld.RESTSharp.ProxyServer;

namespace Palworld.RESTSharp.ProxyService.Database
{
    public interface IAuditRepository : IRepository
    {
        Task Add(UserAudit userAudit);
        Task<IEnumerable<UserAudit>> Get(AuditSearchCriteria criteria);
        Task Clear();
    }
}
