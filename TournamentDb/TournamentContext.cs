using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using TournamentDb.Extensions;

namespace TournamentDb
{
    public class TournamentContext : DbContext
    {
        public TournamentContext()
        {
        }

        public TournamentContext(DbContextOptions<TournamentContext> options) : base(options)
        {
        }

        public DbSet<Match> Matches { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlite(configuration["ConnectionStrings:DefaultConnection"]);
            }

            base.OnConfiguring(optionsBuilder);
        }
        
    }

    public class TournamentContextFactory : IDesignTimeDbContextFactory<TournamentContext>
    {
        public TournamentContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TournamentContext>();
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlite(configuration["ConnectionStrings:DefaultConnection"]);
            return new TournamentContext(optionsBuilder.Options);
        }
    }
}