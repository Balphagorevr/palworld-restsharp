namespace Palworld.RESTSharp
{
    /// <summary>
    /// Represents the location of a player in the game.
    /// </summary>
    public class PlayerLocation
    {
        /// <summary>
        /// X coordinate of the player.
        /// </summary>
        public float x;
        /// <summary>
        /// Y coordinate of the player.
        /// </summary>
        public float y;

        /// <summary>
        /// Create a new player location with provided coordinates.
        /// </summary>
        /// <param name="x">X coordinate of the player.</param>
        /// <param name="y">Y coordinate of the player.</param>
        public PlayerLocation(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
