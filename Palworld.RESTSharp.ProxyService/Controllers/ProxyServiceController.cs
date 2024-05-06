using Microsoft.AspNetCore.Mvc;
using Palworld.RESTSharp.ProxyServer;
using System.Reflection;

namespace Palworld.RESTSharp.ProxyService.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class ProxyServiceController : ControllerBase
    {
        private readonly PalworldRESTSharpProxyConfig config;
        IUserManager userManager;
        IAuditManager auditManager;

        public ProxyServiceController(IConfiguration configuration, IUserManager userManager, IAuditManager auditManager)
        {
            config = configuration.GetSection("PalworldRESTSharpProxyConfig").Get<PalworldRESTSharpProxyConfig>();
            this.userManager = userManager;
            this.auditManager = auditManager;
        }

        #region Audit Endpoints

        [HttpPost("audit/get")]
        public async Task<IActionResult> GetAuditLogs([FromBody] AuditSearchCriteria? auditCriteria)
        {
            try
            {
                User executingUser = await GetExecutingUser();
                if (executingUser.Role != UserAccessLevel.Owner) return Unauthorized("Invalid Token or you do not have permission.");

                var auditData = await auditManager.Get(auditCriteria);

                return Ok(auditData);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("audit/clear")]
        public async Task<IActionResult> ClearAuditLog()
        {
            try
            {
                User executingUser = await GetExecutingUser();
                if (executingUser.Role != UserAccessLevel.Owner) return Unauthorized("Invalid Token or you do not have permission.");

                await auditManager.Clear();

                auditManager.Add(new UserAudit(executingUser.ID, AuditEventType.AuditCleared));

                return Ok("Audit cleared.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        [HttpGet("config")]
        public async Task<IActionResult> ProxyConfig()
        {
            try
            {
                User executingUser = await GetExecutingUser();
                if (executingUser.Role > UserAccessLevel.Moderator) return Unauthorized("Invalid Token or you do not have permission.");

                PalworldRESTSharpProxyConfig returnConfig = new PalworldRESTSharpProxyConfig()
                {
                    ServerRESTUrl = config.ServerRESTUrl,
                    EnableUserAuditing = config.EnableUserAuditing,
                    Version = Assembly.GetExecutingAssembly().GetName().Version.ToString()
                };

                return Ok(returnConfig);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
