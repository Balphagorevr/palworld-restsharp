using Newtonsoft.Json;
using System;

namespace Palworld.RESTSharp.Common
{
    /// <summary>
    /// Represents the root Player object in the JSON response from the server. This will hold the array of players online at the time of response.
    /// </summary>
    public class Players
    {
        /// <summary>
        /// List of players online.
        /// </summary>
        public Player[] players { get; set; }

        /// <summary>
        /// Total number of players online.
        /// </summary>
        [JsonIgnore]
        public int Count => players.Length;

        /// <summary>
        /// Constructor for the Players object.
        /// </summary>
        public Players()
        {
            players = Array.Empty<Player>();
        }
    }

    /// <summary>
    /// Represents a returned player object from the server.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Name of the player in-game.
        /// </summary>
        [JsonProperty("name")]
        public string name { get; set; }

        /// <summary>
        /// Server generated ID of the player. The server may not return a player ID if the player does not have a character or is creating a new character.
        /// </summary>
        [JsonProperty("playerid")]
        public string? playerID { get; set; }

        /// <summary>
        /// Steam ID of the user account.
        /// </summary>
#if REGULAR_NAME
        [JsonProperty("userid")]
#endif
        public string userid { get; set; }

        /// <summary>
        /// IP Address of the user.
        /// </summary>
#if REGULAR_NAME
        [JsonProperty("ip")]
#endif
        public string ip { get; set; }

        /// <summary>
        /// Ping of the user.
        /// </summary>
        [JsonProperty("ping")]
        public float ping { get; set; }

        /// <summary>
        /// Current player game level.
        /// </summary>
        [JsonProperty("level")]
        public float level { get; set; }

        /// <summary>
        /// Gets the X coordinate location of the player.
        /// </summary>
        [JsonProperty("location_x")]
        public float location_x { get; set; }
        /// <summary>
        /// Gets the Y coordinate location of the player.
        /// </summary>
        [JsonProperty("location_y")]
        public float location_y { get; set; }
        /// <summary>
        /// Returns a player location object consisting of the X and Y coordinates of the player at the time of response.
        /// </summary>
        /// <returns>The player location object.</returns>
        public PlayerLocation GetPlayerLocation() => new PlayerLocation(location_x, location_y);
    }
}
