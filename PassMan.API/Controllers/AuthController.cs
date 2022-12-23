using Core.Entities.ComplexTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PassMan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        [HttpPost]
        public IActionResult Login([FromBody] UserLoginDto loginDto)
        {
            return Ok();
        }

    }
}
