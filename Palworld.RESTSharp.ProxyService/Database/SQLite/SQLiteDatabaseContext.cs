using Dapper;
using System.Data.SQLite;

namespace Palworld.RESTSharp.ProxyService.Database.SQLite
{
    public class SQLiteDatabaseContext : IDataContext
    {
        private DatabaseConfiguration dbConfig;

        public SQLiteDatabaseContext(DatabaseConfiguration config)
        {
            dbConfig = config;
        }

        public void Setup()
        {
            using var connection = new SQLiteConnection(dbConfig.ConnectionString);
            CheckTable(connection);
        }

        private void CheckTable(SQLiteConnection connection)
        {
            var type = typeof(IRepository);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract);

            var repositories = types.Select(t => Activator.CreateInstance(t) as IRepository);

            foreach (IRepository repository in repositories)
            {
                var table = connection.Query<string>($"SELECT name FROM sqlite_master WHERE type='table' AND name='{repository.TableName}'").FirstOrDefault();

                if (string.IsNullOrEmpty(table))
                {
                    repository.CreateTable(connection);
                    Console.WriteLine($"Created table {repository.TableName}");
                }
            }
        }
    }
}
