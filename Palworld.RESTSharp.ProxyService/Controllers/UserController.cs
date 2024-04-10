using Microsoft.AspNetCore.Mvc;
using Palworld.RESTSharp.Common;

namespace Palworld.RESTSharp.ProxyService.Controllers
{
    [Route("v1/api/[controller]")]
    public class UserController : ControllerBase
    {
        PalworldRESTSharpProxyConfig _config;
        IUserManager userManager;

        public UserController(
            IConfiguration config,
            IUserManager userManager
            )
        {
            _config = config.GetSection("PalworldRESTSharpProxyConfig").Get<PalworldRESTSharpProxyConfig>();
            this.userManager = userManager;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            try
            {
                if (await AuthorizeUser(["Owner", "Admin", "Moderator"]) == false) return Unauthorized("Invalid Token or you do not have permission.");

                user.Token = Guid.NewGuid().ToString();
                user.ID = await userManager.Add(user);

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
                if (await AuthorizeUser(["Owner", "Admin", "Moderator"]) == false) return Unauthorized("Invalid Token or you do not have permission.");

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
                if (await AuthorizeUser(["Owner", "Admin", "Moderator"]) == false) return Unauthorized("Invalid Token or you do not have permission.");

                User user = await userManager.Get(new User()
                {
                    Token = token
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
                    Token = userToken
                });

                if (user == null) return NotFound("User not found.");

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
                if (await AuthorizeUser(["Owner", "Admin", "Moderator"]) == false) return Unauthorized("Invalid Token or you do not have permission.");

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
                if (await AuthorizeUser(["Owner", "Admin", "Moderator"]) == false) return Unauthorized("Invalid Token or you do not have permission.");

                bool isDeleted = await userManager.Delete(userID);

                if (!isDeleted) return NotFound("User not found.");

                return Ok("User deleted.");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

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
    }
}
