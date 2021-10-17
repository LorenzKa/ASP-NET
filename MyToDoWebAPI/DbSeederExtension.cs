using Microsoft.EntityFrameworkCore;
using MyToDoWebAPI.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoWebAPI
{
    public class DbSeederExtension
    {
        public List<Album> GetAlbums() {
            return File.ReadAllLines(@"CSV/album.csv")
                .Skip(1)
                .Select(l => l.Replace(", ", "REPLACEDTOPARSE").Replace('"', ' ').Trim().Split(","))
                .Select(x => new Album() { ArtistId = int.Parse(x[2]), Id = int.Parse(x[0]), Title = x[1].Replace("REPLACEDTOPARSE", ", ") })
                .ToList();
        }
        public List<Genre> GetGrenes() {
            return File.ReadAllLines(@"CSV/genre.csv")
                .Skip(1)
                .Select(l => l.Replace('"', ' ').Trim().Split(","))
                .Select(x => new Genre() { Id = int.Parse(x[0]), Name = x[1] })
                .ToList();
        }
        public List<PlaylistTrack> GetPlaylistTracks() {
            return File.ReadAllLines(@"CSV/playlist-track.csv")
           .Skip(1)
           .Select(l => l.Replace('"', ' ').Trim().Split(","))
           .Select(x => new PlaylistTrack() { TrackId = int.Parse(x[0]), PlaylistId = int.Parse(x[1]) })
           .ToList();
        }
        public List<Track> GetTracks() {
            return File.ReadAllLines(@"CSV/track.csv")
            .Skip(1)
            .Select(l => l.Split('"' + "," + '"'))
            .Select(x => new Track()
            {
                Id = int.Parse(x[0].Replace('"', ' ').Trim()),
                Name = x[1].Replace('"', ' ').Trim(),
                AlbumId = int.Parse(x[2].Replace('"', ' ').Trim()),
                MediaTypeId = int.Parse(x[3].Replace('"', ' ').Trim()),
                GenreId = int.Parse(x[4].Replace('"', ' ').Trim()),
                Composer = x[5].Replace('"', ' ').Trim(),
                Milliseconds = int.Parse(x[6].Replace('"', ' ').Trim()),
                Bytes = int.Parse(x[7].Replace('"', ' ').Trim()),
                UnitPrice = double.Parse(x[8].Replace('"', ' ').Trim()),
            })
            .ToList();
        }
        public List<Playlist> GetPlaylists() {

            return File.ReadAllLines(@"CSV/playlist.csv")
            .Skip(1)
            .Select(l => l.Replace('"', ' ').Trim().Split(","))
            .Select(x => new Playlist() { Id = int.Parse(x[0]), Name = x[1] })
            .ToList();
        }
    }
}
