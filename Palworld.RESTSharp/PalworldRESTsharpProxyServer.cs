using Palworld.RESTSharp.Common;

namespace Palworld.RESTSharp
{
    public class PalworldRESTsharpProxyServer
    {
        /// <summary>
        /// Gets the build version of the Palweorld RESTSharp API Proxy server.
        /// </summary>
        public string Version { get; internal set; }

        /// <summary>
        /// The local user authenticated with the Palworld RESTSharp API Proxy server.
        /// </summary>

        public User? LocalUser { get; internal set; }

    }
}
