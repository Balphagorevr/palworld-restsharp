
using Newtonsoft.Json;

namespace Palworld.RESTSharp
{
    public class ServerInfo
    {
        /// <summary>
        /// Version of the server build.
        /// </summary>
        [JsonProperty("version")]
        public string version { get; set; }
        /// <summary>
        /// Name of the server
        /// </summary>
        [JsonProperty("servername")]
        public string serverName { get; set; }
        /// <summary>
        /// Description of the server.
        /// </summary>
        [JsonProperty("description")]
        public string description { get; set; }


        public override string ToString() => $"[{serverName}][{version}][{description}]";
    }
}
