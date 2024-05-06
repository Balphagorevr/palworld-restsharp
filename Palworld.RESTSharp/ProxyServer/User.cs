namespace Palworld.RESTSharp.ProxyServer
{
    /// <summary>
    /// A user object used for the Proxy Server Authorization and Authentication.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Database generated ID of the user.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Username of the user.
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// The user's password.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Whether or not the user account is enabled.
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// Specifies the access level of the user to specific functions on the Proxy server.
        /// </summary>
        public UserAccessLevel Role { get; set; }
    }

    /// <summary>
    /// Defines the access level for the user.
    /// </summary>
    public enum UserAccessLevel
    {
        /// <summary>
        /// Owners can add/modify/remove proxy users and configure the proxy server.
        /// </summary>
        Owner,
        /// <summary>
        /// Admins can perform advanced functions such as broadcasting, rebooting and more.
        /// </summary>
        Admin,
        /// <summary>
        /// Moderators can kick and ban users.
        /// </summary>
        Moderator
    }
}
