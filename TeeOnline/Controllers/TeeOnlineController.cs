using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TeeOnline.Controllers
{
    
    [ApiController]
    public class TeeOnlineController : ControllerBase
    {
        [Route("")]
        public IActionResult login(string email, string password)
        {

        }
    }
}
