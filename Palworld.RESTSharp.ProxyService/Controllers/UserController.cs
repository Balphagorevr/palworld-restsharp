using Microsoft.AspNetCore.Mvc;
using Palworld.RESTSharp.ProxyServer;

namespace Palworld.RESTSharp.ProxyService.Controllers
{
    [Route("v1/api/[controller]")]
    public class UserController : ControllerBase
    {
        IUserManager userManager;
        IAuditManager auditManager;

        public UserController(IUserManager userManager, IAuditManager auditManager)
        {
            this.userManager = userManager;
            this.auditManager = auditManager;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            try
            {
                if (!await AuthenticateUser(UserAccessLevel.Owner)) return Unauthorized("Invalid Token or you do not have permission.");
                User executingUser = await GetExecutingUser();
                user.ID = await userManager.Add(user);

                auditManager.Add(new UserAudit(executingUser.ID, AuditEventType.UserCreated, $"NewUserID={user.ID};User={user.Username};Role={user.Role};"));

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                if (!await AuthenticateUser(UserAccessLevel.Owner)) return Unauthorized("Invalid Token or you do not have permission.");

                return Ok(await userManager.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("get/{token}")]
        public async Task<IActionResult> GetUserByToken(string token)
        {
            try
            {
                if (!await AuthenticateUser(UserAccessLevel.Owner)) return Unauthorized("Invalid Token or you do not have permission.");

                User user = await userManager.Get(new User()
                {
                    Password = token
                });

                if (user == null) return NotFound("User not found.");

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            try
            {
                string userToken = Request.Headers["Authorization"];
                userToken = userToken.Replace("Bearer ", "").Replace("Basic ", "");

                User user = await userManager.Get(new User()
                {
                    Password = userToken
                });

                if (user == null) return NotFound("User token not found.");

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            try
            {
                if (!await AuthenticateUser(UserAccessLevel.Owner)) return Unauthorized("Invalid Token or you do not have permission.");

                User executingUser = await GetExecutingUser();
                auditManager.Add(new UserAudit(executingUser.ID, AuditEventType.UserEdited, $"User={user.Username};FinalRole={user.Role};."));


                await userManager.UpdateUser(user);

                return Ok("User updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("delete/{userID}")]
        public async Task<IActionResult> DeleteUser(int userID)
        {
            try
            {
                if (!await AuthenticateUser(UserAccessLevel.Owner)) return Unauthorized("Invalid Token or you do not have permission.");

                User executingUser = await GetExecutingUser();
                auditManager.Add(new UserAudit(executingUser.ID, AuditEventType.UserEdited, $"DeletedUserID={userID};."));

                bool isDeleted = await userManager.Delete(userID);

                if (!isDeleted) return NotFound("User not found.");

                return Ok(isDeleted);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private async Task<bool> AuthenticateUser(UserAccessLevel level)
        {
            string userToken = Request.Headers["Authorization"];
            if (String.IsNullOrEmpty(userToken))
            {
                return false;
            }

            userToken = userToken.Replace("Bearer ", "");
            return await userManager.GetAccessLevel(new User()
            {
                Password = userToken
            }) <= level;
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
