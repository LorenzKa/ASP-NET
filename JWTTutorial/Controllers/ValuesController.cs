using JWTTutorial.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTTutorial.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public DummyDataDto Dummy()
        {
            return new DummyDataDto
            {
                IntVal = DateTime.Now.Second,
                StringVal = $"{DateTime.Now:HH:mm:ss0}"
            };
        }
    }
}
