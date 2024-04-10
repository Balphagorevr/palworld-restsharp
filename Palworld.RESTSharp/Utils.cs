using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace Palworld.RESTSharp
{
    internal static class Utils
    {
        /// <summary>
        /// Gets the encoded auth string for the given password for BASIC auth.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        internal static string GetEncodedAuth(string password)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes($"admin:{password}"));
        }

        internal static HttpRequestMessage CreateHttpPostRequest(string apiEndpoint, object requestData)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, apiEndpoint);
            string json = JsonConvert.SerializeObject(requestData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            requestMessage.Content = content;
            return requestMessage;
        }

        internal static void ValidateResponse(HttpResponseMessage response)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new PalworldRESTSharpClientUnauthorizedException(response.Content.ReadAsStringAsync().Result);
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new PalworldRESTSharpClientBadRequestException(response.Content.ReadAsStringAsync().Result);

            response.EnsureSuccessStatusCode();
        }
    }
}
