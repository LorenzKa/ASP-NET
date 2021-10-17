using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyToDoWebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoWebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class MusicPlaylistEditorController : ControllerBase
    {
        private readonly static DbSeederExtension Seeder = new DbSeederExtension();
        private readonly static List<Track> tracks = Seeder.GetTracks();
        private readonly static List<Playlist> playlists = Seeder.GetPlaylists();
        private readonly static List<Genre> genres = Seeder.GetGrenes();
        private readonly static List<Album> albums = Seeder.GetAlbums();
        private readonly static List<PlaylistTrack> playlistTracks = Seeder.GetPlaylistTracks();

        [Route("playlists")]
        [HttpGet]
        public IActionResult outputAllPlaylists()
        {
            return Ok(playlists);
        }
        [Route("playlisttracks/{index}")]
        [HttpGet]
        public IActionResult outputTracksForPlaylists(int index)
        {
            List<int> trackIdList = playlistTracks.Where(x => x.PlaylistId == index).Select(x => x.TrackId).ToList();
            List<Track> trackList = new List<Track>();
            for (int i = 0; i < trackIdList.Count; i++)
            {
                trackList.Add(tracks.Where(x => x.Id == trackIdList[i]).First());
            }
            return Ok(trackList);
        }
        [Route("genres")]
        [HttpGet]
        public IActionResult outputAllGenres()
        {
            return Ok(genres);
        }
        [Route("albums")]
        [HttpGet]
        public IActionResult outputAllAlbums()
        {
            return Ok(albums);
        }
        [Route("tracks")]
        [HttpGet]
        public IActionResult outputTracksForGenre([FromQuery] int genreid)
        {
            return Ok(tracks.Where(x => x.GenreId == genreid).ToList());
        }
        [Route("track")]
        [HttpPost]
        public IActionResult addTrack([FromBody] PlaylistTrack playlistTrack)
        {
            playlistTracks.Add(playlistTrack);
            return Ok(playlistTracks.Where(x => x ==  playlistTrack).First());
        }
        [Route("track")]
        [HttpDelete]
        public IActionResult deleteTrack([FromQuery] int playlistid, [FromQuery] int trackid)
        {
            playlistTracks.Remove(playlistTracks.Where(x => x.PlaylistId == playlistid && x.TrackId == trackid).First());
            return NoContent();
        }
    }
}
