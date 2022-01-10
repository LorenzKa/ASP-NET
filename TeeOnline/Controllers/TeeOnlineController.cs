using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeeOnline.Dtos;
using TeeOnline.Services;

namespace TeeOnline.Controllers
{
    
    [ApiController]
    public class TeeOnlineController : ControllerBase
    {
        TeeOnlineService service;

        public TeeOnlineController(TeeOnlineService service)
        {
            this.service = service;
        }

        [Route("authentication/login")]
        [HttpPost]
        public IActionResult login(LoginDto data)
        {
            return Ok( service.login(data.Email, data.Password));
        }
    }
}
