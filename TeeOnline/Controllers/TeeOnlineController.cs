using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeeOnline.Dtos;
using TeeOnline.Services;

namespace TeeOnline.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TeeOnlineController : ControllerBase
    {
        private readonly TeeOnlineService service;

        public TeeOnlineController(TeeOnlineService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult login(LoginDto data)
        {
            return Ok( service.login(data.Email, data.Password));
        }
        [HttpGet]
        public IActionResult players()
        {
            return Ok( service.players());
        }
    }
}
