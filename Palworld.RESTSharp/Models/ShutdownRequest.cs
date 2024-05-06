using Newtonsoft.Json;

namespace Palworld.RESTSharp
{
    /// <summary>
    /// For requesting server to shutdown.
    /// </summary>
    public class ShutdownRequest
    {
        /// <summary>
        /// Wait time in seconds.
        /// </summary>
        [JsonProperty("waittime")]
        public int WaitTime { get; set; }
        /// <summary>
        /// Message to display for server shutdown.
        /// </summary>
        [JsonProperty("Message")]
        public string Message { get; set; }

        public ShutdownRequest(int waittime, string message)
        {
            WaitTime = waittime;
            Message = message;
        }
    }
}
