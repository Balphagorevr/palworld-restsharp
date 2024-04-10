using Microsoft.AspNetCore.Mvc;
using Palworld.RESTSharp.Common;

namespace Palworld.RESTSharp.ProxyService.Controllers
{
    [Route("v1/api")]
    public class PalworldController : ControllerBase
    {
        PalworldRESTSharpProxyConfig config;
        PalworldRESTSharpClient palworldRESTSharpClient;
        IUserManager userManager;

        private async Task<bool> AuthorizeUser(string[] roles)
        {
            string userToken = Request.Headers["Authorization"];
            if (String.IsNullOrEmpty(userToken))
            {
                return false;
            }

            userToken = userToken.Replace("Bearer ", "");
            return await userManager.TokenHasRoles(userToken, roles);
        }

        public PalworldController(
            IConfiguration configuration,
            IUserManager userManager)
        {
            config = configuration.GetSection("PalworldRESTSharpProxyConfig").Get<PalworldRESTSharpProxyConfig>();
            palworldRESTSharpClient = new PalworldRESTSharpClient(config.ServerRESTUrl, config.PalworldServerAdminPass);
            this.userManager = userManager;
        }

        [HttpGet("Info")]
        public async Task<IActionResult> Info()
        {
            return Ok(await palworldRESTSharpClient.GetServerInfoASync());
        }

        [HttpGet("players")]
        public async Task<IActionResult> Players()
        {
            if (await AuthorizeUser(["Owner","Admin","Moderator"]) == false) return Unauthorized("Invalid Token or you do not have permission.");
            return Ok(await palworldRESTSharpClient.GetPlayersASync());
        }

        [HttpGet("settings")]
        public async Task<IActionResult> Settings()
        {
            if (await AuthorizeUser(["Owner", "Admin", "Moderator"]) == false) return Unauthorized("Invalid Token or you do not have permission.");
            return Ok(await palworldRESTSharpClient.GetServerSettingsASync());
        }

        [HttpGet("metrics")]
        public async Task<IActionResult> Metrics()
        {
            return Ok(await palworldRESTSharpClient.GetServerMetricsASync());
        }

        [HttpPost("announce")]
        public async Task<IActionResult> AnnounceAsync([FromBody] string message)
        {
            if (await AuthorizeUser(["Owner", "Admin", "Moderator"]) == false) return Unauthorized("Invalid Token or you do not have permission.");
            await palworldRESTSharpClient.BroadcastMessageASync(message);
            return Ok("Broadcasted message.");
        }

        [HttpPost("kick")]
        public async Task<IActionResult> Kick([FromBody] PlayerAction playerAction)
        {
            if (await AuthorizeUser(["Owner", "Admin", "Moderator"]) == false) return Unauthorized("Invalid Token or you do not have permission.");
            await palworldRESTSharpClient.KickPlayerASync(playerAction.steamID, playerAction.message);

            return Ok("Kicked player.");
        }

        [HttpPost("ban")]
        public async Task<IActionResult> Ban([FromBody] PlayerAction playerAction)
        {
            if (await AuthorizeUser(["Owner", "Admin", "Moderator"]) == false) return Unauthorized("Invalid Token or you do not have permission.");
            await palworldRESTSharpClient.BanPlayerASync(playerAction.steamID, playerAction.message);

            return Ok("Banned player.");
        }

        [HttpPost("shutdown")]
        public async Task<IActionResult> Shutdown([FromBody] ShutdownRequest shutdownRequest)
        {
            if (await AuthorizeUser(["Owner", "Admin", "Moderator"]) == false) return Unauthorized("Invalid Token or you do not have permission.");
            await palworldRESTSharpClient.ShutdownASync(shutdownRequest.waittime, shutdownRequest.message);

            return Ok("Shutdown requested.");
        }

        [HttpPost("stop")]
        public async Task<IActionResult> Stop()
        {
            if (await AuthorizeUser(["Owner", "Admin", "Moderator"]) == false) return Unauthorized("Invalid Token or you do not have permission.");
            await palworldRESTSharpClient.StopServerASync();

            return Ok("Stop requested.");
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save()
        {
            if (await AuthorizeUser(["Owner", "Admin", "Moderator"]) == false) return Unauthorized("Invalid Token or you do not have permission.");
            await palworldRESTSharpClient.SaveWorldASync();

            return Ok("World saved.");
        }
    }
}