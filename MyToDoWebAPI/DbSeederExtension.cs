using Microsoft.EntityFrameworkCore;
using MyToDoWebAPI.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoWebAPI
{
    public static class DbSeederExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var list = 
            modelBuilder.Entity<Album>().HasData(
                File.ReadAllLines(@"CSV/album.csv")
                .Skip(1)
                .Select(l => l.Replace(", ", "REPLACEDTOPARSE").Replace('"', ' ').Trim().Split(","))
                .Select(x => new Album() { ArtistId = int.Parse(x[2]), Id = int.Parse(x[0]), Title = x[1].Replace("REPLACEDTOPARSE", ", ") })
                .ToList()
                );
            modelBuilder.Entity<Genre>().HasData(
                File.ReadAllLines(@"CSV/genre.csv")
                .Skip(1)
                .Select(l => l.Replace('"', ' ').Trim().Split(","))
                .Select(x => new Genre() { Id = int.Parse(x[0]), Name = x[1]})
                .ToList()
                );
            modelBuilder.Entity<Playlist>().HasData(
                File.ReadAllLines(@"CSV/playlist.csv")
                .Skip(1)
                .Select(l => l.Replace('"', ' ').Trim().Split(","))
                .Select(x => new Playlist() { Id = int.Parse(x[0]), Name = x[1] })
                .ToList()
                );
            modelBuilder.Entity<PlaylistTrack>().HasData(
                File.ReadAllLines(@"CSV/playlist-track.csv")
                .Skip(1)
                .Select(l => l.Replace('"', ' ').Trim().Split(","))
                .Select(x => new PlaylistTrack() { Id = int.Parse(x[0]), TrackId = int.Parse(x[1]) })
                .ToList()
                );
            var test = File.ReadAllLines(@"CSV/track.csv")
                .Skip(1)
                .Select(l => l.Replace(", ", "REPLACEDTOPARSE").Replace('"', ' ').Trim().Split(",")).ToList();
            File.WriteAllLines("test.csv", test[0]);
            modelBuilder.Entity<Track>().HasData(
                File.ReadAllLines(@"CSV/track.csv")
                .Skip(1)
                .Select(l => l.Replace(", ", "REPLACEDTOPARSE").Replace('"', ' ').Trim().Split(","))
                .Select(x => new Track() { Id = int.Parse(x[0]),
                    Name = x[1].Replace("REPLACEDTOPARSE", ""),
                    AlbumId = int.Parse(x[2]),
                    MediaTypeId = int.Parse(x[3]),
                    GenreId = int.Parse(x[4]),
                    Composer = x[5].Replace("REPLACEDTOPARSE", ""),
                    Milliseconds = int.Parse(x[6]),
                    Bytes = int.Parse(x[7]),
                    UnitPrice = double.Parse(x[8])})
                .ToList() 
                );

        }
    }
}
