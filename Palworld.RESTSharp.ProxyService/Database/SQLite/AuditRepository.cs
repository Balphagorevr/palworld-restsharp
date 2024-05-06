
using Dapper;
using Palworld.RESTSharp.ProxyServer;
using System.Data.SQLite;

namespace Palworld.RESTSharp.ProxyService.Database.SQLite
{
    public class AuditRepository : IAuditRepository
    {
        private readonly DatabaseConfiguration dbConfig;
        public string TableName { get => "AuditLog"; set { } }
        public string TableColumns { get => "AuditDate, AuditUserID, AuditEvent, AuditDetails"; set { } }

        public AuditRepository() { }

        public AuditRepository(DatabaseConfiguration databaseConfig)
        {
            dbConfig = databaseConfig;
        }

        public async Task CreateTable(SQLiteConnection connection, DatabaseConfiguration dbConfig)
        {
            string createTable = $"CREATE TABLE [{TableName}] ([AuditDate] DateTime, AuditUserID INT, AuditEvent TINYINT, AuditDetails TEXT NULL)";

            await connection.ExecuteAsync(createTable);
        }

        public async Task Add(UserAudit userAudit)
        {
            using var connection = new SQLiteConnection(dbConfig.ConnectionString);

            await connection.ExecuteAsync($"INSERT INTO {TableName}({TableColumns}) VALUES (@AuditDate, @AuditUserID, @AuditEvent, @AuditDetails)", userAudit);

        }

        public async Task Clear()
        {
            using var connection = new SQLiteConnection(dbConfig.ConnectionString);

            await connection.ExecuteAsync($"DELETE FROM {TableName}");

        }

        public async Task<IEnumerable<UserAudit>> Get(AuditSearchCriteria? criteria)
        {
            using var connection = new SQLiteConnection(dbConfig.ConnectionString);

            if (criteria == null)
            {
                return await connection.QueryAsync<UserAudit>($"SELECT AuditUserID, AuditDate, Username, AuditEvent, AuditDetails FROM {TableName} aud INNER JOIN Users u ON aud.AuditUserID = u.rowid");
            }
            else
            {
                return await connection.QueryAsync<UserAudit>($"SELECT AuditUserID, AuditDate, Username, AuditEvent, AuditDetails FROM {TableName} aud INNER JOIN Users u ON aud.AuditUserID = u.rowid WHERE AuditUserID = IFNULL(@AuditUserID, AuditUserID) AND AuditEvent = IFNULL(@AuditEvent,AuditEvent) AND AuditDate BETWEEN IFNULL(@FromDate,AuditDate) AND IFNULL(@ToDate,AuditDate)", criteria);

            }
        }
    }
}
