using Newtonsoft.Json;
using System;

namespace Palworld.RESTSharp
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
        [JsonProperty]
        public int count => players.Length;

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
        public string PlayerName { get; set; }

        /// <summary>
        /// Server generated ID of the player. The server may not return a player ID if the player does not have a character or is creating a new character.
        /// </summary>
        [JsonProperty("playerid")]
        public string? PlayerID { get; set; }

        /// <summary>
        /// Steam ID of the user account.
        /// </summary>
#if REGULAR_NAME
        [JsonProperty("userid")]
#endif
        public string UserID { get; set; }

        /// <summary>
        /// IP Address of the user.
        /// </summary>
#if REGULAR_NAME
        [JsonProperty("ip")]
#endif
        public string IP { get; set; }

        /// <summary>
        /// Ping of the user.
        /// </summary>
        [JsonProperty("ping")]
        public float Ping { get; set; }

        /// <summary>
        /// Current player game level.
        /// </summary>
        [JsonProperty("level")]
        public float Level { get; set; }

        /// <summary>
        /// Gets the X coordinate location of the player.
        /// </summary>
        [JsonProperty("location_x")]
        public float XPosition { get; set; }
        /// <summary>
        /// Gets the Y coordinate location of the player.
        /// </summary>
        [JsonProperty("location_y")]
        public float YPosition { get; set; }
        /// <summary>
        /// Returns a player location object consisting of the X and Y coordinates of the player at the time of response.
        /// </summary>
        /// <returns>The player location object.</returns>
        public PlayerLocation GetPlayerLocation() => new PlayerLocation(XPosition, YPosition);
    }
}
