namespace Palworld.RESTSharp.Common
{
    /// <summary>
    /// Announce Request Object for sending broadcasts in-game chat.
    /// </summary>
    public class AnnounceMessage
    {
        /// <summary>
        /// The message to be anoounced.
        /// </summary>
        public string message { get; set; }

        public AnnounceMessage(string message)
        {
            this.message = message;
        }
    }
}
