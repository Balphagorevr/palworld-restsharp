namespace Palworld.RESTSharp.Common
{
    /// <summary>
    /// For requesting server to shutdown.
    /// </summary>
    public class ShutdownRequest
    {
        /// <summary>
        /// Wait time in seconds.
        /// </summary>
        public int waittime { get; set; }
        /// <summary>
        /// Message to display for server shutdown.
        /// </summary>
        public string message { get; set; }

        public ShutdownRequest(int waittime, string message)
        {
            this.waittime = waittime;
            this.message = message;
        }
    }
}
