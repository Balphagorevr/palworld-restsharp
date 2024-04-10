using Newtonsoft.Json;

namespace Palworld.RESTSharp.Common
{
    /// <summary>
    /// Represents a server metric object returned from the API.
    /// </summary>
    public class ServerMetric
    {
        /// <summary>
        /// The FPS of the server.
        /// </summary>
        [JsonProperty("serverfps")]
        public int serverFPS { get; set; }
        /// <summary>
        /// Total number of players on the server.
        /// </summary>
        [JsonProperty("currentplayernum")]
        public int totalPlayers { get; set; }
        /// <summary>
        /// Server frame time measured in milliseconds.
        /// </summary>
        [JsonProperty("serverframetime")]
        public float serverFrameRate { get; set; }
        /// <summary>
        /// Maximum number of players allowed on the server.
        /// </summary>
        [JsonProperty("maxplayernum")]
        public int maxPlayers { get; set; }
        /// <summary>
        /// Uptime of the server in seconds.
        /// </summary>
        [JsonProperty("uptime")]
        public int upTime { get; set; }

        /// <summary>
        /// Gets the uptime of the server expressed in hours, minutes, and seconds.
        /// </summary>
        /// <returns></returns>
        public string GetUptimeString()
        {
            int days = upTime / 86400;
            int hours = upTime / 3600;
            int minutes = upTime % 3600 / 60;
            int seconds = upTime % 60;
            return $"{days}d {hours}h {minutes}m {seconds}s";
        }
    }
}
