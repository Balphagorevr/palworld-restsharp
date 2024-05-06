using Newtonsoft.Json;
using Palworld.RESTSharp.ProxyServer;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Palworld.RESTSharp
{
    /// <summary>
    /// The Palworld REST API Client provides a way to interact with the Palworld server via REST API.<br></br><br></br>You will need to have 'RESTAPIEnabled=True,RESTAPIPort=xxxxx' in your server configuration file. Be sure to specify and open the port you provide within RESTAPIPort.
    /// </summary>
    public class PalworldRESTSharpClient : HttpClient
    {
        #region Private fields
        /// <summary>
        /// URL to the PalServer REST API service.
        /// </summary>
        private string _restAPIURL;

        #endregion

        #region Public fields
        /// <summary>
        /// Configuration for the Poxy Service REST API client.
        /// </summary>
        public PalworldRESTSharpProxyServer ProxyServer { get; internal set; }

        /// <summary>
        /// Configuration for the REST API client.
        /// </summary>
        public PalworldRESTSharpClientConfig Configuration { get; internal set; }

        /// <summary>
        /// Shares information about the Pal server such as the server name, version, and description.
        /// </summary>
        public ServerInfo PalServerInfo { get; internal set; }

        /// <summary>
        /// Returns true if the endpoint is the Palworld RESTsharp proxy server.
        /// </summary>
        public readonly bool UsingProxy;

        #endregion

        #region Constructors
        /// <summary>
        /// HTTP Client to conneect to PalServer REST API service with pre-defined API URL and password.
        /// </summary>
        /// <remarks>
        /// It is <u>advised</u> to NOT expose your REST API port to the internet as the Palworld serveer REST API only communicates through HTTP and uses BASIC authentication which can expose your server password through the internet. Consider using a HTTPS proxy server between your REST API and the internet.
        /// <br></br><br></br>You will need to have <strong>'RESTAPIEnabled=True,RESTAPIPort=xxxxx'</strong> in your server configuration file. Be sure to specify and open the port you provide within RESTAPIPort.
        /// <br></br><br></br><see href="https://tech.palworldgame.com/api/rest-api/palwold-rest-api">Consult the Palworld server documentation for more information on how to set up the REST API</see>
        /// </remarks>
        /// <param name="apiURL">URL to the PalServer REST API hostname/IP and port.</param>
        /// <param name="password">The password defined in the 'AdminPassword' setting of your server configuration.</param>
        /// <param name="timeout">The timeout in seconds for the connection to the REST API server.</param>
        /// <param name="useProxy">Use PalSharp REST API Proxy server endpoints instead.</param>
        public PalworldRESTSharpClient(string apiURL, string password, bool useProxy = false, short timeout = 30)
        {
            Configuration = new PalworldRESTSharpClientConfig(apiURL, password, timeout);
            UsingProxy = useProxy;
            Task.Run(() => ConnectAsync()).Wait();
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Configures HTTP client and prepares to connect to the Palworld REST API service.
        /// </summary>
        /// <returns></returns>
        private async Task ConnectAsync()
        {
            _restAPIURL = Configuration.APIEndpointURL;
            Timeout = new TimeSpan(0, 0, Configuration.ConnectionTimeout);
            BaseAddress = new Uri($"{_restAPIURL}/");

            if (UsingProxy)
            {
                this.ProxyServer = new PalworldRESTSharpProxyServer(this);
            }
            else
            {
                // We're connected directly to the Pal REST API Server, uses Basic.
                DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Utils.GetEncodedAuth(Configuration.Password));
            }

            this.PalServerInfo = await GetServerInfoASync();
        }
        #endregion

        #region Server Information
        /// <summary>
        /// Gets the metrics of the server.
        /// </summary>
        /// <returns>Server Metric object.</returns>
        public async Task<ServerMetric> GetServerMetricsASync()
        {
            HttpResponseMessage response = await GetAsync("v1/api/metrics");

            Utils.ValidateResponse(response);

            ServerMetric metric = JsonConvert.DeserializeObject<ServerMetric>(await response.Content.ReadAsStringAsync());

            return metric;
        }

        /// <summary>
        /// Gets the server information.
        /// </summary>
        /// <returns>Server Information object.</returns>
        public async Task<ServerInfo> GetServerInfoASync()
        {
            if (PalServerInfo != null) return PalServerInfo;

            HttpResponseMessage response = await GetAsync("v1/api/info");

            Utils.ValidateResponse(response);

            PalServerInfo = JsonConvert.DeserializeObject<ServerInfo>(await response.Content.ReadAsStringAsync());

            return PalServerInfo;
        }

        /// <summary>
        /// Gets a list of all players playing in the server.
        /// </summary>
        /// <returns>Array of player objects.</returns>
        public async Task<Players> GetPlayersASync() 
        {
            HttpResponseMessage response = await GetAsync("v1/api/players");

            Utils.ValidateResponse(response);

            string stringContent = await response.Content.ReadAsStringAsync();

            Players players = JsonConvert.DeserializeObject<Players>(stringContent);

            return players;
        }

        /// <summary>
        /// Gets the server settings configuration..
        /// </summary>
        /// <returns>Sever Settings object with all available values.</returns>
        public async Task<ServerSettings> GetServerSettingsASync()
        {
            HttpResponseMessage response = await GetAsync("v1/api/settings");

            Utils.ValidateResponse(response);

            ServerSettings serverSettings = JsonConvert.DeserializeObject<ServerSettings>(await response.Content.ReadAsStringAsync());

            return serverSettings;
        }
        #endregion

        #region Player Management
        /// <summary>
        /// Kicks a player from the server.
        /// </summary>
        /// <param name="player">Steam ID(steam_xxxxxxxxxxx) of the player to kick.</param>
        public async Task KickPlayerASync(string steamID, string message) => await KickPlayerASync(new Player() { UserID = steamID }, message);

        /// <summary>
        /// Kicks a player from the server.
        /// </summary>
        /// <param name="player">Player object</param>
        public async Task KickPlayerASync(Player player, string message)
        {
            HttpRequestMessage requestMessage = Utils.CreateHttpPostRequest("v1/api/kick", new PlayerAction(player.UserID, message));
            HttpResponseMessage response = await SendAsync(requestMessage);

            Utils.ValidateResponse(response);
        }

        /// <summary>
        /// Bans a player from the server.
        /// </summary>
        /// <param name="steamID">Steam ID(steam_xxxxxxxxxxx) of the player to ban.</param>
        public async Task BanPlayerASync(string steamID, string message) => await BanPlayerASync(new Player() { UserID = steamID }, message);

        /// <summary>
        /// Bans a player from the server.
        /// </summary>
        /// <param name="player">Player to ban. Must have Steam ID present.</param>
        public async Task BanPlayerASync(Player player, string message)
        {
            HttpRequestMessage requestMessage = Utils.CreateHttpPostRequest("v1/api/ban", new PlayerAction(player.UserID, message));
            HttpResponseMessage response = await SendAsync(requestMessage);

            Utils.ValidateResponse(response);
        }

        /// <summary>
        /// Unbans a player from the server.
        /// </summary>
        /// <param name="steamID">Steam ID(steam_xxxxxxxxxxx) of the player to unban.</param>
        public async Task UnbanPlayerASync(string steamID) => await UnbanPlayerASync(new Player() { UserID = steamID });

        /// <summary>
        /// Bans a player from the server.
        /// </summary>
        /// <param name="player">Player to unban. Must have Steam ID present.</param>
        public async Task UnbanPlayerASync(Player player)
        {
            HttpRequestMessage requestMessage = Utils.CreateHttpPostRequest("v1/api/unban", new PlayerAction(player.UserID, null));
            HttpResponseMessage response = await SendAsync(requestMessage);

            Utils.ValidateResponse(response);
        }

        #endregion

        #region Server Management
        /// <summary>
        /// Saves the world.
        /// </summary>
        public async Task SaveWorldASync()
        {
            HttpRequestMessage requestMessage = Utils.CreateHttpPostRequest("v1/api/save", "");
            HttpResponseMessage response = await SendAsync(requestMessage);

            Utils.ValidateResponse(response);
        }

        /// <summary>
        /// Broadcasts a message to the server chat. Equivalent to the /broadcast command.
        /// </summary>
        /// <remarks>
        /// Your message will be sent as "[SYSTEM]" in chat.
        /// </remarks>
        /// <param name="message">The message to broadcast.</param>
        public async Task BroadcastMessageASync(string message)
        {
            AnnounceMessage announceMessage = new AnnounceMessage(message);

            if (string.IsNullOrEmpty(announceMessage.Message)) throw new ArgumentNullException(nameof(message), "Message cannot be null or empty.");

            HttpRequestMessage requestMessage = Utils.CreateHttpPostRequest("v1/api/announce", announceMessage);
            HttpResponseMessage response = await SendAsync(requestMessage);

            Utils.ValidateResponse(response);
        }

        /// <summary>
        /// Broadcasts a message to the server chat. Equivalent to the /broadcast command.
        /// </summary>
        /// <remarks>
        /// Your message will be sent as "[SYSTEM]" in chat.
        /// </remarks>
        /// <param name="message">The message to broadcast.</param>
        public async Task BroadcastMessageASync(AnnounceMessage message)
        {
            if (string.IsNullOrEmpty(message.Message)) throw new ArgumentNullException(nameof(message), "Message cannot be null or empty.");

            HttpRequestMessage requestMessage = Utils.CreateHttpPostRequest("v1/api/announce", message);
            HttpResponseMessage response = await SendAsync(requestMessage);

            Utils.ValidateResponse(response);
        }

        /// <summary>
        /// Requests the server to broadcast a message and then shutdown after a specified time.
        /// </summary>
        public async Task ShutdownASync(int waitTime, string message)
        {
            if (waitTime <= 0) throw new ArgumentOutOfRangeException(nameof(waitTime), "Wait time must be greater than 0.");
            if (string.IsNullOrEmpty(message)) throw new ArgumentNullException(nameof(message), "Message cannot be null or empty.");

            HttpRequestMessage requestMessage = Utils.CreateHttpPostRequest("v1/api/shutdown", new ShutdownRequest(waitTime, message));
            HttpResponseMessage response = await SendAsync(requestMessage);

            Utils.ValidateResponse(response);
        }

        /// <summary>
        /// Requests the server to forcefully stop.
        /// </summary>
        /// <remarks>
        /// It is <u>not advised</u> to use this command without saving the world prior. You may lose progress or corrupt the save file.
        /// </remarks>
        public async Task StopServerASync()
        {
            HttpRequestMessage requestMessage = Utils.CreateHttpPostRequest("v1/api/stop", new {});
            HttpResponseMessage response = await SendAsync(requestMessage);

            Utils.ValidateResponse(response);
        }
        #endregion
    }
}