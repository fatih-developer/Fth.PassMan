using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PassMan.API.Models;

namespace PassMan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordService _passwordService;

        public PasswordController(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }


        [HttpPost("getpassword")]
        public IActionResult GetPassword([FromBody] GetPasswordModel model)
        {
            var result = _passwordService.GetPasswordsByVisible(model.Password);
            return Ok(result);
        }
    }
}
