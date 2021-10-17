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
        private readonly static Seeder Seeder = new();
        private readonly static List<Track> tracks = Seeder.GetTracks();
        private readonly static List<Playlist> playlists = Seeder.GetPlaylists();
        private readonly static List<Genre> genres = Seeder.GetGrenes();
        private readonly static List<Album> albums = Seeder.GetAlbums();
        private readonly static List<PlaylistTrack> playlistTracks = Seeder.GetPlaylistTracks();

        [Route("playlists")]
        [HttpGet]
        public IActionResult outputAllPlaylists()
        {
            if(playlists.Count > 0)
            {
                return Ok(playlists);
            }
            else
            {
                return NotFound();
            }
        }
        [Route("playlisttracks/{index}")]
        [HttpGet]
        public IActionResult outputTracksForPlaylists(int index)
        {
            if (index > 0)
            {
                List<int> trackIdList = playlistTracks.Where(x => x.PlaylistId == index).Select(x => x.TrackId).ToList();
                if (trackIdList.Count > 0)
                {
                    List<Track> trackList = new List<Track>();
                    for (int i = 0; i < trackIdList.Count; i++)
                    {
                        trackList.Add(tracks.Where(x => x.Id == trackIdList[i]).First());
                    }
                    return Ok(trackList);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }
        [Route("genres")]
        [HttpGet]
        public IActionResult outputAllGenres()
        {
            if (genres.Count > 0)
            {
                return Ok(genres);
            }
            else
            {
                return NotFound();
            }
        }
        [Route("albums")]
        [HttpGet]
        public IActionResult outputAllAlbums()
        {
            if (albums.Count > 0)
            {
                return Ok(albums);
            }
            else
            {
                return NotFound();
            }
        }
        [Route("tracks")]
        [HttpGet]
        public IActionResult outputTracksForGenre([FromQuery] int genreid)
        {
            if (genreid > 0)
            {
                var tracksList =  tracks.Where(x => x.GenreId == genreid).ToList();
                if(tracksList.Count > 0)
                {
                    return Ok(tracksList);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }
        [Route("track")]
        [HttpPost]
        public IActionResult addTrack([FromBody] PlaylistTrack playlistTrack)
        {
            if (playlistTrack.PlaylistId > 0 && playlistTrack.TrackId > 0)
            {
                if (playlists.Find(x => x.Id == playlistTrack.PlaylistId) != null && tracks.Find(x => x.Id == playlistTrack.TrackId) != null)
                {
                    playlistTracks.Add(playlistTrack);
                    return Ok(playlistTracks.Where(x => x == playlistTrack).First());
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }
        [Route("track")]
        [HttpDelete]
        public IActionResult deleteTrack([FromQuery] int playlistid, [FromQuery] int trackid)
        {
            if(playlistid > 0 && trackid > 0)
            {
                var toRemove = playlistTracks.Where(x => x.PlaylistId == playlistid && x.TrackId == trackid).First();
                if (toRemove != null)
                {
                    playlistTracks.Remove(playlistTracks.Where(x => x.PlaylistId == playlistid && x.TrackId == trackid).First());
                    return NoContent();
                }
                return NotFound();
            }
            return BadRequest();
        }
    }
}
