using Palworld.RESTSharp.ProxyServer;
using Palworld.RESTSharp.ProxyService.Database;

namespace Palworld.RESTSharp.ProxyService
{
    public interface IAuditManager
    {
        IAuditRepository auditRepository { get; set; }
        Task Add(UserAudit userAudit);
        Task Clear();
        Task<IEnumerable<UserAudit>> Get(AuditSearchCriteria criteria);
    }
    public class AuditManager : IAuditManager
    {
        public IAuditRepository auditRepository { get; set; }

        public AuditManager(IAuditRepository auditRepository)
        {
            this.auditRepository = auditRepository;
        }
        public async Task Add(UserAudit userAudit)
        {
            await auditRepository.Add(userAudit);
        }

        public async Task Clear()
        {
            await auditRepository.Clear();
        }

        public async Task<IEnumerable<UserAudit>> Get(AuditSearchCriteria criteria)
        {
            return await auditRepository.Get(criteria);
        }
    }
}
