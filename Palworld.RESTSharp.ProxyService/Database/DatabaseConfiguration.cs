namespace Palworld.RESTSharp.ProxyService.Database
{
    public interface IDatabaseConfiguration
    {
        public string ConnectionString { get; set; }
    }

    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        private Dictionary<string, string> _options { get; set; }

        public string ConnectionString { get; set; }
        public Dictionary<string, string> Options
        {
            get
            {
                return _options;
            }
            set
            {
                _options = value;
            }
        }

        public DatabaseConfiguration(string connectionString, Dictionary<string, string> options)
        {
            this.ConnectionString = connectionString;
            _options = options;
        }
    }
}
