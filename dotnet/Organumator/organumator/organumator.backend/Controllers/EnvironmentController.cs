using Microsoft.AspNetCore.Mvc;
using organumator.Dtos;

namespace organumator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnvironmentController(IWebHostEnvironment environment) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCurrent()
        {
            return Ok(new EnvironmentDto { Environment = environment.EnvironmentName });
        }
    }
}
