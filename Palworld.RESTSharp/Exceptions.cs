using System;

namespace Palworld.RESTSharp
{
    /// <summary>
    /// Exceptions that are thrown by the Palworld RestSharp client.
    /// </summary>
    public class PalworldRESTSharpClientException : Exception
    {
        public PalworldRESTSharpClientException(string message) : base($"PalworldRESTAPIClient: {message}")
        {

        }
    }
    /// <summary>
    /// Thrown when the client is not authorized to perform the requested action.
    /// </summary>
    public class PalworldRESTSharpClientUnauthorizedException : PalworldRESTSharpClientException
    {
        public PalworldRESTSharpClientUnauthorizedException(string message) : base(message)
        {

        }
    }

    /// <summary>
    /// Thrown when the client receives a bad request response from the server.
    /// </summary>
    public class PalworldRESTSharpClientBadRequestException : PalworldRESTSharpClientException
    {
        public PalworldRESTSharpClientBadRequestException(string message) : base(message)
        {

        }
    }

    /// <summary>
    ///  Thrown when the client receives an invalid response from the server.
    /// </summary>
    public class PalworldRESTSharpClientInvalidResponse : PalworldRESTSharpClientException
    {
        public PalworldRESTSharpClientInvalidResponse(string message) : base(message)
        {

        }
    }

    /// <summary>
    /// Thrown when the client receives a not found response from the server.
    /// </summary>
    public class PalworldRESTSharpClientNotFoundException : PalworldRESTSharpClientException
    {
        public PalworldRESTSharpClientNotFoundException(string message) : base(message)
        {

        }
    }
}
