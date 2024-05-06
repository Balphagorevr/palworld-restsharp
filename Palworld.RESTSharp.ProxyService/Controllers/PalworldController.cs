using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Palworld.RESTSharp.ProxyServer;

namespace Palworld.RESTSharp.ProxyService.Controllers
{
    [Route("v1/api")]
    public class PalworldController : ControllerBase
    {
        PalworldRESTSharpProxyConfig config;
        PalworldRESTSharpClient palworldRESTSharpClient;
        IUserManager userManager;
        IAuditManager auditManager;

        public PalworldController(
            IConfiguration configuration,
            IUserManager userManager,
            IAuditManager auditManager)
        {
            config = configuration.GetSection("PalworldRESTSharpProxyConfig").Get<PalworldRESTSharpProxyConfig>();
            palworldRESTSharpClient = new PalworldRESTSharpClient(config.ServerRESTUrl, config.PalworldServerAdminPass);
            this.auditManager = auditManager;
            this.userManager = userManager;
        }

        [HttpGet("info")]
        public async Task<IActionResult> Info()
        {
            return Ok(JsonConvert.SerializeObject(await palworldRESTSharpClient.GetServerInfoASync()));
        }

        [HttpGet("players")]
        public async Task<IActionResult> Players()
        {
            User executingUser = await GetExecutingUser();
            if (executingUser.Role > UserAccessLevel.Moderator) return Unauthorized("Invalid Token or you do not have permission.");
            return Ok(JsonConvert.SerializeObject(await palworldRESTSharpClient.GetPlayersASync()));
        }

        [HttpGet("settings")]
        public async Task<IActionResult> Settings()
        {
            User executingUser = await GetExecutingUser();
            if (executingUser.Role > UserAccessLevel.Admin) return Unauthorized("Invalid Token or you do not have permission.");

            return Ok(JsonConvert.SerializeObject(await palworldRESTSharpClient.GetServerSettingsASync()));
        }

        [HttpGet("metrics")]
        public async Task<IActionResult> Metrics()
        {
            return Ok(JsonConvert.SerializeObject(await palworldRESTSharpClient.GetServerMetricsASync()));
        }

        [HttpPost("announce")]
        public async Task<IActionResult> AnnounceAsync([FromBody] AnnounceMessage message)
        {
            User executingUser = await GetExecutingUser();
            if (executingUser.Role > UserAccessLevel.Moderator) return Unauthorized("Invalid Token or you do not have permission.");

            auditManager.Add(new UserAudit(executingUser.ID, AuditEventType.BroadcastMessage, $"Message={message.Message}"));

            await palworldRESTSharpClient.BroadcastMessageASync(message);

            return Ok("Broadcasted message.");
        }

        [HttpPost("kick")]
        public async Task<IActionResult> Kick([FromBody] PlayerAction playerAction)
        {
            User executingUser = await GetExecutingUser();
            if (executingUser.Role > UserAccessLevel.Moderator) return Unauthorized("Invalid Token or you do not have permission.");

            auditManager.Add(new UserAudit(executingUser.ID, AuditEventType.KickPlayer, $"SteamID={playerAction.SteamID};Reason={playerAction.Message}"));

            await palworldRESTSharpClient.KickPlayerASync(playerAction.SteamID, playerAction.Message);
            return Ok("Kicked player.");
        }

        [HttpPost("ban")]
        public async Task<IActionResult> Ban([FromBody] PlayerAction playerAction)
        {
            User executingUser = await GetExecutingUser();
            if (executingUser.Role > UserAccessLevel.Moderator) return Unauthorized("Invalid Token or you do not have permission.");

            auditManager.Add(new UserAudit(executingUser.ID, AuditEventType.BanPlayer, $"SteamID={playerAction.SteamID};Reason={playerAction.Message}"));

            await palworldRESTSharpClient.BanPlayerASync(playerAction.SteamID, playerAction.Message);

            return Ok("Banned player.");
        }

        [HttpPost("shutdown")]
        public async Task<IActionResult> Shutdown([FromBody] ShutdownRequest shutdownRequest)
        {
            User executingUser = await GetExecutingUser();
            if (executingUser.Role > UserAccessLevel.Admin) return Unauthorized("Invalid Token or you do not have permission.");

            auditManager.Add(new UserAudit(executingUser.ID, AuditEventType.ShutdownServer, $"Seconds={shutdownRequest.WaitTime};Message={shutdownRequest.Message}"));

            await palworldRESTSharpClient.ShutdownASync(shutdownRequest.WaitTime, shutdownRequest.Message);

            return Ok("Shutdown requested.");
        }

        [HttpPost("stop")]
        public async Task<IActionResult> Stop()
        {
            User executingUser = await GetExecutingUser();
            if (executingUser.Role > UserAccessLevel.Admin) return Unauthorized("Invalid Token or you do not have permission.");

            auditManager.Add(new UserAudit(executingUser.ID, AuditEventType.StopServer));
            
            await palworldRESTSharpClient.StopServerASync();

            return Ok("Stop requested.");
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save()
        {
            User executingUser = await GetExecutingUser();
            if (executingUser.Role > UserAccessLevel.Admin) return Unauthorized("Invalid Token or you do not have permission.");

            auditManager.Add(new UserAudit(executingUser.ID, AuditEventType.WorldSaved));

            await palworldRESTSharpClient.SaveWorldASync();

            return Ok("World saved.");
        }

        private async Task<User?> GetExecutingUser()
        {
            string userToken = Request.Headers.Authorization;
            userToken = userToken.Replace("Bearer ", "");

            if (String.IsNullOrEmpty(userToken))
            {
                return null;
            }

            return await userManager.Get(new User()
            {
                Password = userToken
            });
        }
    }
}