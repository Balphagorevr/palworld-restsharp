namespace Palworld.RESTSharp.ProxyServer
{
    /// <summary>
    /// Represents the configuration settings for the Palworld RESTSharp API Proxy server.
    /// </summary>
    public class PalworldRESTSharpProxyConfig
    {
        /// <summary>
        /// Gets or sets the URL of the Palworld RESTSharp API Proxy server.
        /// </summary>
        public string ServerRESTUrl { get; set; }
        /// <summary>
        /// Whether or not user actions should be recorded in the audit log.
        /// </summary>
        public bool EnableUserAuditing { get; set; }
        /// <summary>
        /// Represents the password for the Palworld Server REST API.(Same as your RCON password)
        /// </summary>
        public string PalworldServerAdminPass { get; internal set; }
        /// <summary>
        /// Version of the Palworld RESTSharp API Proxy server.
        /// </summary>
        public string Version { get; set; }
    }
}
