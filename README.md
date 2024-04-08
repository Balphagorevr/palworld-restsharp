<p align="center"><image src="https://github.com/Balphagorevr/palworld-rconsharp/blob/master/RestSharpLogo-128.png?raw=true"></image></p>
<h1 align="center">Palworld RESTSharp</h1>
<p align="center">A C# library for the Palworld Dedicated Server REST API.

## :warning: Disclaimer :warning:
It is not advised to expose your REST API to the internet since it does not support HTTPS and only uses Basic authentication which sends your password through plain text.

If you must expose it to the internet, please use a reverse proxy with HTTPS support. **We are not responsible** if your server was hacked and you did not secure your REST endpoint.

Should Pocketpair release support for HTTPS and better authentication, I will update this library to support it.

## :wrench: Requirements
* You must have the following values configured in your _PalWorldSettings.ini_ file
	* RESTAPIEnabled=True
	* RESTAPIPort=xxxx (Specify your preferred port)
	* AdminPassword=**** (You should already have this configured to access your RCON/In-game Admin rights).

## Getting Started

### Install Nu-Get Package
1. Visit the linked NuGet release page/package and download.

### Clone and build your own
You can choose to clone this repository and build the library yourself.

## :electric_plug: Using the Library
```csharp
using Palworld.RESTSharp;

// Create a new instance of the PalworldClient
palworldRESTAPIClient = new PalworldRESTSharpClient("http://127.0.0.1:8000", "MyAdminPassword123");

// Get the server information.
ServerInfo serverInfo = await palworldRESTAPIClient.GetServerInfoASync();

console.WriteLine($serverInfo.serverName);

// Broadcast a message to the in-game chat.
await palworldRESTAPIClient.BroadcastMessageASync("Hello World!");

// Get the player list.
Players palPlayers = await palworldRESTAPIClient.GetPlayersASync();

// Enumerate the list of online players returned from the server.
foreach (Player player in palPlayers.players)
{
	Console.WriteLine(player.name);
}
```

## :construction: Roadmap
* Add player coordinate translation to in-game map coordinates.
* Create player markers on in-game map.
* Create a ASP.NET Core site to demonstrate and use library within a webpage and serve a HTTPS reverse proxy.
* Optimizations.
* Setup CI/CD pipeline and publish to NuGet.

## :grey_question: Questions/Support
Feel free to join https://discord.galacticpals.net for assistance or have questions.
You can open an issue on this repository as well.