using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordCrackerApi.Dtos;

namespace PasswordCrackerApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /*[HttpGet]
        public async Task<IActionResult> Password0()
        {
            var worker = new Worker();
            var crackRequest = new CrackRequestDto()
            {
                Alphabet = "abcdefghijklmnopqrstuvwxyz",
                HashCode = "A746222F09D85605C52D4E636788D6FFDC274698B98B8C5F3244C06958683A69",
                Length = 4
            };
            var resultTask = worker.BruteforcePoolManager(crackRequest.HashCode, crackRequest.Length, crackRequest.Alphabet.ToCharArray());
            var result = await resultTask;
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> Password1()
        {
            var worker = new Worker();
            var crackRequest = new CrackRequestDto()
            {
                Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                HashCode = "3086E346353248775A2C5D74E36A9C9B9BD226A1EE401F830AC499633DC00031",
                Length = 6
            };
            var resultTask = worker.BruteforcePoolManager(crackRequest.HashCode, crackRequest.Length, crackRequest.Alphabet.ToCharArray());
            var result = await resultTask;
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> Password2()
        {
            var worker = new Worker();
            var crackRequest = new CrackRequestDto()
            {
                Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789",
                HashCode = "26775436073E00D207E192857EE3730CFCA19DE16F01F0780096EF217C2919EF",
                Length = 5
            };
            var resultTask = worker.BruteforcePoolManager(crackRequest.HashCode, crackRequest.Length, crackRequest.Alphabet.ToCharArray());
            var result = await resultTask;
            return Ok(result);
        }
        */
    }
}
