using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyToDoWebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly MusicContext db;

        public TrackController(MusicContext db)
        {
            this.db = db;
        }


        [HttpGet]
        public IActionResult outputTracksForGenre([FromQuery] int genreid)
        {
            return Ok(db.Tracks.Where(x => x.GenreId == genreid).ToList());
        }
        [HttpPost]
        public IActionResult addTrack([FromBody] PlaylistTrack playlistTrack)
        {
            db.PlaylistTracks.Add(playlistTrack);
            db.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult deleteTrack([FromQuery] int playlistid, [FromQuery] int trackid)
        {
            db.PlaylistTracks.Remove(db.PlaylistTracks.Where(x => x.Id == playlistid && x.TrackId == trackid).First());
            db.SaveChanges();
            return Ok();
        }
    }
}
