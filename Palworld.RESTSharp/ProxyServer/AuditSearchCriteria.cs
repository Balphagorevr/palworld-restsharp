using System;

namespace Palworld.RESTSharp.ProxyServer
{
    public class AuditSearchCriteria
    {
        public int AuditUserID { get; set; }
        public string AuditUsername { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public AuditEventType AuditEvent { get; set; }
    }
}
