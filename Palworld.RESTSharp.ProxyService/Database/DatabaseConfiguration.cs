namespace Palworld.RESTSharp.ProxyService.Database
{
    public interface IDatabaseConfiguration
    {
        public string ConnectionString { get; set; }
    }

    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        public string ConnectionString { get; set; }

        public DatabaseConfiguration(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
    }
}
