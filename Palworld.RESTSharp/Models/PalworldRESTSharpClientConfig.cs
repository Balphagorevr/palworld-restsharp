namespace Palworld.RESTSharp
{
    public class PalworldRESTSharpClientConfig
    {
        private string _password;

        public string Password { get => _password; set => _password = value; }

        public short ConnectionTimeout { get; set; }
        public readonly string APIEndpointURL;

        public PalworldRESTSharpClientConfig() { }
        public PalworldRESTSharpClientConfig(string aPIEndpointURL, string password, short connectionTimeout = 30)
        {
            _password = password;
            ConnectionTimeout = connectionTimeout;
            APIEndpointURL = aPIEndpointURL;
        }
    }
}
