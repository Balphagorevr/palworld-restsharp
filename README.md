<p align="center"><image src="https://github.com/Balphagorevr/palworld-rconsharp/blob/master/RestSharpLogo-128.png?raw=true"></image></p>
<h1 align="center">Palworld RESTSharp</h1>
<p align="center">A C# library for the Palworld Dedicated Server REST API.

![GitHub Release](https://img.shields.io/github/v/release/BalphagoreVR/palworld-restsharp) 
<a href="https://www.nuget.org/packages/Palworld.RESTSharp">![NuGet Version](https://img.shields.io/nuget/v/Palworld.RESTSharp)
</a>

## :warning: Disclaimer :warning:
I advise you to NOT expose your REST API to the internet since it does not support HTTPS and only uses Basic authentication which sends your password through plain text.

If you must expose it to the internet, please consider installing and using our proxy service which supports HTTPS and has user access rights built-in. Or use a HTTPS proxy server

**We are not responsible** if your server was hacked and you did not secure your REST endpoint.

## :wrench: Requirements
* You must have the following values configured in your _PalWorldSettings.ini_ file
	* RESTAPIEnabled=True
	* RESTAPIPort=xxxx (Specify your preferred port)
	* AdminPassword=**** (You should already have this configured to access your RCON/In-game Admin rights).

# Getting Started

## Palworld RESTSharp Library
The library provides an abstraction of API methods ready for use to communicate with the Palworld dedicated server's REST API.
### Installation and setup
#### NuGet Package
1. Search on NuGet either through nuget.org or via link: https://www.nuget.org/packages/Palworld.RESTSharp.		
#### Build from Source
1. Clone this repository and build the library yourself.
1. Distribute and include your library to your own projects.

### :electric_plug: Using the Library
```csharp
using Palworld.RESTSharp;

// Create a new instance of the PalworldClient
palworldRESTAPIClient client = new PalworldRESTSharpClient("http://127.0.0.1:8000", "MyAdminPassword123");

// Get the server information.
ServerInfo serverInfo = await client.GetServerInfoASync();

console.WriteLine(serverInfo.serverName);

// Broadcast a message to the in-game chat.
await client.BroadcastMessageASync("Hello World!");

// Get the player list.
Players palPlayers = await client.GetPlayersASync();

// Enumerate the list of online players returned from the server.
foreach (Player player in palPlayers.players)
{
	Console.WriteLine(player.name);
}
```

## Palworld RESTSharp Proxy Service
The proxy service provides a HTTPS server that exposes the Palworld REST API methods behind the HTTPS secure protocol and provides basic user level access that can restrict specific methods and include audit logging of admin actions.

### Features
* Can run under IIS or as a standalone service.
* Create user accounts with access to specific methods via roles such as admin or moderator.
* Audit admin and moderator actions.
* Mandatory HTTPS support for security.
* Supports ALL available REST API methods provided by the PalServer REST API.

### Installation and setup
#### Download Binaries
You can download the binaries from the release page OR build the project yourself.

#### Configuration(Standalone)
1. Open "appsettings.json" file and provide the URL/port and admin password for the Palworld Dedicated Server REST API.
1. Specify the listen IP and port for the proxy service which is curently set to 7135.
1. Provide the path to your SSL certificate and password for HTTPS(Required).

```json
  "PalworldRESTSharpProxyConfig": {
    "ServerRESTUrl": "http://127.0.0.1:8000",
    "PalworldServerAdminPass": "MyAdminPass"
  }
  "Kestrel": {
    "EndPoints": {
      "Https": {
        "Url": "https://*:7135",
        "Certificate": {
          "Path": "MySSLCert.pfx",
          "Password": "MySSLPass123"
        }
      }
    }
  }
```

#### Configuration(IIS)
The proxy service can also be hosted on IIS. The Web.Config is already setup and you will need to install ASP.NET Core Hosting Bundle on your server.
If you run it under IIS, you don't need to worry about configuring the URL/Port and SSL certificate as you would set that up under IIS.

#### Using Proxy Server from Palworld RESTSharp Library
```csharp
using Palworld.RESTSharp;
using Palworld.RESTSharp.ProxyServer;

// Create a new PalworldRESTSharpClient instance with the proxy server URL and 'true' for the third argument to use proxy server mode.
palworldRESTAPIClient palAPIClient = new PalworldRESTSharpClient("http://mypalapi.net:8000", "AdminPassword", true);

// Access the proxy user details to get the user's roles and other information from the proxy server.
ProxyUser localUser = palAPIClient.ProxyServer.ProxyUser;

// Do the same actions as if you were just connected to the Palworld REST API. 
// The proxy server will receive your requests, checks if you have permission to execute the action and forward them to the Palworld REST API.
await palAPIClient.BroadcastMessageASync("Hello World!");
```

# :construction: Roadmap
## Palworld RESTsharp Library
* Add player coordinate translation to in-game map coordinates.
* Optimizations.
## Palworld RESTSharp Proxy Service
* Add Docker support to run under Docker.
* Add user access audit logging
* Add displayable map with player locations demonstrating the use of player coordinates given by the REST API.


## :grey_question: Questions/Support
Feel free to join https://discord.galacticpals.net for assistance or have questions.
You can open an issue on this repository as well.

If you'd like to leave a tip, you can buy me a Hazelnut Truffle Mocha to keep me awake while coding. :coffee:

<a href='https://ko-fi.com/P5P7VJ0PZ' target='_blank'><img height='36' style='border:0px;height:36px;' src='https://storage.ko-fi.com/cdn/kofi2.png?v=3' border='0' alt='Buy Me a Coffee at ko-fi.com' /></a>
