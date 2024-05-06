using Newtonsoft.Json;

namespace Palworld.RESTSharp
{
    /// <summary>
    /// Represents an action to be taken upon a player with a message.
    /// </summary>
    public class PlayerAction
    {
        /// <summary>
        /// The target useer's Steam ID.
        /// </summary>
        [JsonProperty("userid")]
        public string SteamID { get; set; }
        /// <summary>
        /// The message to include in the action such as kick or ban.
        /// </summary>
        [JsonProperty("message")]
        public string? Message { get; set; }
        public PlayerAction() { }
        public PlayerAction(string steamID, string? message)
        {
            SteamID = steamID;
            Message = message;
        }
    }
}
