<p align="center"><image src="https://github.com/Balphagorevr/palworld-rconsharp/blob/master/RestSharpLogo-128.png?raw=true"></image></p>
<h1 align="center">Palworld RESTSharp</h1>
<p align="center">A C# library for the Palworld Dedicated Server REST API.

![GitHub Release](https://img.shields.io/github/v/release/BalphagoreVR/palworld-restsharp) 
<a href="https://www.nuget.org/packages/Palworld.RESTSharp">![NuGet Version](https://img.shields.io/nuget/v/Palworld.RESTSharp)
</a>

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
Search on NuGet either through nuget.org or your NuGet package manager of choice.

https://www.nuget.org/packages/Palworld.RESTSharp/

### Clone and build your own
You can choose to clone this repository and build the library yourself.

## :electric_plug: Using the Library
```csharp
using Palworld.RESTSharp;

// Create a new instance of the PalworldClient
palworldRESTAPIClient client = new PalworldRESTSharpClient("http://127.0.0.1:8000", "MyAdminPassword123");

// Get the server information.
ServerInfo serverInfo = await client.GetServerInfoASync();

console.WriteLine($serverInfo.serverName);

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

## :construction: Roadmap
* Add player coordinate translation to in-game map coordinates.
* Create player markers on in-game map.
* Create a ASP.NET Core site to demonstrate and use library within a webpage and serve a HTTPS reverse proxy.
* Optimizations.

## :grey_question: Questions/Support
Feel free to join https://discord.galacticpals.net for assistance or have questions.
You can open an issue on this repository as well.

If you'd like to leave a tip, you can buy me a Hazelnut Truffle Mocha to keep me awake while coding. :coffee:

<a href='https://ko-fi.com/P5P7VJ0PZ' target='_blank'><img height='36' style='border:0px;height:36px;' src='https://storage.ko-fi.com/cdn/kofi2.png?v=3' border='0' alt='Buy Me a Coffee at ko-fi.com' /></a>
