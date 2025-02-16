using Newtonsoft.Json;
namespace Palworld.RESTSharp
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
        public int ServerFPS { get; set; }
        /// <summary>
        /// Total number of players on the server.
        /// </summary>
        [JsonProperty("currentplayernum")]
        public int CurrentPlayers { get; set; }
        /// <summary>
        /// Server frame time measured in milliseconds.
        /// </summary>
        [JsonProperty("serverframetime")]
        public float ServerFrameTime { get; set; }
        /// <summary>
        /// Maximum number of players allowed on the server.
        /// </summary>
        [JsonProperty("maxplayernum")]
        public int MaxPlayers { get; set; }
        /// <summary>
        /// Uptime of the server in seconds.
        /// </summary>
        [JsonProperty("uptime")]
        public int Uptime { get; set; }
        /// <summary>
        /// Total number of in-game days that has passed since the world was created.
        /// </summary>
        [JsonProperty("days")]
        public int Days { get; set; }
        /// <summary>
        /// Gets the uptime of the server expressed in hours, minutes, and seconds.
        /// </summary>
        /// <returns></returns>
        public string GetUptimeString()
        {
            int days = Uptime / 86400;
            int hours = Uptime / 3600;
            int minutes = Uptime % 3600 / 60;
            int seconds = Uptime % 60;
            return $"{days}d {hours}h {minutes}m {seconds}s";
        }
    }
}
