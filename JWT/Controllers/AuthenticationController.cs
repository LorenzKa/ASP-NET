
using JWT.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserService userService;

        public AuthenticationController(UserService userService)
        {
            this.userService = userService;
        }
        [HttpPost]
        public ActionResult<AuthenticationDto> Authenticate([FromBody] UserDto userDto)
        {
            var result = userService.Authenticate(userDto.Username, userDto.Password);
            if (result == false) return Unauthorized();
            string token = userService.CreateToken(userDto);
            return Ok(new AuthenticationDto
            {
                Username = userDto.Username,
                Token = token
            });
        }
        
    }
}
