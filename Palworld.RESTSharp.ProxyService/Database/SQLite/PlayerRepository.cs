using Dapper;
using Palworld.RESTSharp.ProxyServer;
using System.Data.SQLite;

namespace Palworld.RESTSharp.ProxyService.Database.SQLite
{
    public class PlayerRepository
    {
        public PlayerRepository() { }

        public string TableName { get => "Players"; set { } }
        public string TableColumns { get => "AuditDate, AuditUserID, AuditEvent, AuditDetails"; set { } }


    }
}
