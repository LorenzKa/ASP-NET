using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyToDoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly MusicContext db;

        public PlaylistController(MusicContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult outputAllPlaylists()
        {
            return Ok(db.Playlists.ToList());
        }

        [HttpGet]
        [Route("{index}")]
        public IActionResult outputTracksForPlaylists(int index)
        {
            return Ok(db.PlaylistTracks);
        }
    }
}
