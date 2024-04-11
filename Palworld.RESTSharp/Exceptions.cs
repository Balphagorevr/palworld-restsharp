using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palworld.RESTSharp
{
    public class PalworldRESTSharpClientException : Exception
    {
        public PalworldRESTSharpClientException(string message) : base($"PalworldRESTAPIClient: {message}")
        {

        }
    }

    public class PalworldRESTSharpClientUnauthorizedException : PalworldRESTSharpClientException
    {
        public PalworldRESTSharpClientUnauthorizedException(string message) : base(message)
        {

        }
    }

    public class PalworldRESTSharpClientBadRequestException : PalworldRESTSharpClientException
    {
        public PalworldRESTSharpClientBadRequestException(string message) : base(message)
        {

        }
    }

    public class PalworldRESTSharpClientInvalidResponse : PalworldRESTSharpClientException
    {
        public PalworldRESTSharpClientInvalidResponse(string response, string expectedResponse) : base($"Expected response: {expectedResponse}. Got '{response}' instead.")
        {

        }
    }

    public class PalworldRESTSharpClientNotFoundException : PalworldRESTSharpClientException
    {
        public PalworldRESTSharpClientNotFoundException(string message) : base(message)
        {

        }
    }
}
