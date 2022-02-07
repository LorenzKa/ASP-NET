using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordCrackerApi.Dtos;

namespace PasswordCrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [Route("test")]
        [HttpGet]
        public async Task<IActionResult> test()
        {
            var worker = new Worker();
            var crackRequest = new CrackRequestDto()
            {
                Alphabet = "abcdefghijklmnopqrstuvwxyz",
                HashCode = "A746222F09D85605C52D4E636788D6FFDC274698B98B8C5F3244C06958683A69",
                Length = 4
            };
            var resultTask = worker.BruteforcePool(crackRequest);
            var result = await resultTask;
            return Ok(result);
        }
    }
}
