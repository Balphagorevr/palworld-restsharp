using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;

namespace Palworld.RESTSharp.ProxyServer
{
    /// <summary>
    /// Provides API methods to interact with the Palworld RESTSharp API Proxy server.
    /// </summary>
    public class PalworldRESTSharpProxyServer
    {
        /// <summary>
        /// Gets the URL of the proxy server.
        /// </summary>
        public readonly string ProxyURL;
        /// <summary>
        /// Gets the build version of the Palweorld RESTSharp API Proxy server.
        /// </summary>
        public readonly string Version;

        /// <summary>
        /// The local user authenticated with the Palworld RESTSharp API Proxy server.
        /// </summary>
        public readonly User? ProxyUser;

        private PalworldRESTSharpClient _client { get; set; }
        private PalworldRESTSharpProxyConfig? _proxyConfig { get; set; }

        /// <summary>
        /// Creates an instance of the PalworldRESTSharpProxyServer. The instance piggybacks off of the PalworldRESTSharpClient instance to communicate with the proxy server.
        /// </summary>
        /// <param name="restSharpClient">The PAlworldRESTSharpClient instance that will be used to communicate with the Proxy server.</param>
        internal PalworldRESTSharpProxyServer(PalworldRESTSharpClient restSharpClient)
        {
            _client = restSharpClient;
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _client.Configuration.Password);

            ProxyURL = _client.BaseAddress.OriginalString;
            ProxyUser = Task.Run(async () => await GetUserProfileASync()).Result;
            _proxyConfig = Task.Run(async () => await GetProxyPalServerConfigASync()).Result;
            Version = _proxyConfig?.Version ?? "Unknown";

            ValidateProxyVersion();

        }

        /// <summary>
        /// Checks to see if the proxy server and the library are compatible with each other.
        /// </summary>
        /// <exception cref="Exception"></exception>
        private void ValidateProxyVersion()
        {
            Version version = new Version(_proxyConfig?.Version ?? "1.0.0");
            Version assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;

            if (version < assemblyVersion)
            {
                throw new Exception("The Proxy server version out of date and incompatible with this library. Consider updating the proxy server.");
            }
            else if (version > assemblyVersion)
            {
                throw new Exception("The PalworldRESTSharp library is out of date and is incompatible with the Proxy server. Consider updating the library.");
            }
        }

        /// <summary>
        /// Gets the user profile information.
        /// </summary>
        /// <returns></returns>
        public async Task<User> GetUserProfileASync()
        {
            HttpResponseMessage response = await _client.GetAsync("v1/api/user/profile");

            Utils.ValidateResponse(response);

            return JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Gets the proxy server configuration.
        /// </summary>
        /// <returns></returns>
        public async Task<PalworldRESTSharpProxyConfig> GetProxyPalServerConfigASync()
        {
            HttpResponseMessage response = await _client.GetAsync("v1/api/proxyservice/config");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return null;

            Utils.ValidateResponse(response);

            return JsonConvert.DeserializeObject<PalworldRESTSharpProxyConfig>(await response.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Gets all users from the proxy server.
        /// </summary>
        /// <returns></returns>
        public async Task<User[]> GetUsersASync()
        {
            HttpResponseMessage response = await _client.GetAsync("v1/api/user/get");

            Utils.ValidateResponse(response);

            return JsonConvert.DeserializeObject<User[]>(await response.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Adds a new user to the proxy server.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<string> AddUserASync(User user)
        {

            HttpRequestMessage requestMessage = Utils.CreateHttpPostRequest("v1/api/user/add", user);
            HttpResponseMessage response = await _client.SendAsync(requestMessage);

            Utils.ValidateResponse(response);

            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Deletes a user from the proxy server.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public async Task<string> DeleteUserASync(int userID)
        {

            HttpResponseMessage response = await _client.DeleteAsync($"v1/api/user/delete/{userID}");

            Utils.ValidateResponse(response);

            return await response.Content.ReadAsStringAsync();
        }
        /// <summary>
        /// Updates a user from the proxy server.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<string> UpdateUserASync(User user)
        {

            HttpRequestMessage requestMessage = Utils.CreateHTTPPutRequest("v1/api/user/update", user);
            HttpResponseMessage response = await _client.SendAsync(requestMessage);

            Utils.ValidateResponse(response);

            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Gets the user audit log from the database.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public async Task<UserAudit[]> GetUserAuditLogASync(AuditSearchCriteria criteria)
        {

            HttpRequestMessage requestMessage = Utils.CreateHttpPostRequest("v1/api/proxyservice/audit/get", criteria);
            HttpResponseMessage response = await _client.SendAsync(requestMessage);

            Utils.ValidateResponse(response);

            return JsonConvert.DeserializeObject<UserAudit[]>(await response.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Clears the entire audit log table.
        /// </summary>
        /// <returns></returns>
        public async Task ClearAuditLogASync()
        {
            HttpResponseMessage response = await _client.DeleteAsync("v1/api/proxyservice/audit/clear");

            Utils.ValidateResponse(response);
        }
    }
}
