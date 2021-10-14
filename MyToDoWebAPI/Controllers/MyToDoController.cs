using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoWebAPI.Controllers
{
    [Route("contacts")]
    [ApiController]
    public class MyToDoController : ControllerBase
    {
        private readonly MusicContext db;

        public MyToDoController(MusicContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult outputAll()
        {
            return Ok(db.PlaylistTracks.Count());
        }


    }
}
