using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Palworld.RESTSharp.ProxyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProxyServiceController : ControllerBase
    {
        [HttpGet("version")]
        public async Task<IActionResult> Version()
        {
            try
            {
                // Get version of the assembly build.
                Version serviceVersion = Assembly.GetExecutingAssembly().GetName().Version;

                return Ok(serviceVersion.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
