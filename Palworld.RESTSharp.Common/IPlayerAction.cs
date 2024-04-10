using Newtonsoft.Json;

namespace Palworld.RESTSharp.Common
{
    public interface IPlayerAction
    {
        [JsonProperty("userid")]
        public string steamID { get; set; }
        public string? message { get; set; }
    }

    public class PlayerAction : IPlayerAction
    {
        public string steamID { get; set; }
        public string? message { get; set; }
        public PlayerAction(string steamID, string? message)
        {
            this.steamID = steamID;
            this.message = message;
        }
    }
}
