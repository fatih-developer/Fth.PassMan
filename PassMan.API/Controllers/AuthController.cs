using Business.Abstract;
using Core.Entities.ComplexTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PassMan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserLoginDto loginDto)
        {

            var resultLogin = _authService.PasswordSignInAsync(loginDto.Username, loginDto.Password, false).Result;


            return Ok(resultLogin);
        }

    }
}
