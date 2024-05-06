using Newtonsoft.Json;

namespace Palworld.RESTSharp
{
    /// <summary>
    /// Announce Request Object for sending broadcasts in-game chat.
    /// </summary>
    public class AnnounceMessage
    {
        /// <summary>
        /// The message to be anoounced.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        public AnnounceMessage() { }

        public AnnounceMessage(string message)
        {
            Message = message;
        }
    }
}
