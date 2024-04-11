using System.Data.SQLite;

namespace Palworld.RESTSharp.ProxyService.Database
{
    public interface IRepository
    {
        public string TableName { get; set; }
        public string TableColumns { get; set; }
        Task CreateTable(SQLiteConnection connection, DatabaseConfiguration datacbaseConfig);
    }
}
