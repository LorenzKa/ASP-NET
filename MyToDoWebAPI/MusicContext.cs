using Microsoft.EntityFrameworkCore;
using MyToDoWebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoWebAPI
{
    public class MusicContext : DbContext
    {
        public  MusicContext(DbContextOptions<MusicContext> options):base(options) { }
        public MusicContext() { }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistTrack> PlaylistTracks { get; set; }
        public DbSet<Track> Tracks { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "server=(LocalDB)\\mssqllocaldb; attachdbfilename=C:\\OneDrive\\Schule\\5_Klasse\\POS\\MDFs\\Music.mdf; database=MusicDb";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DbSeederExtension.Seed(modelBuilder);
        }
    }
}
