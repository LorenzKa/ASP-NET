using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentDb
{
    public static class DbSeederExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasData(File.ReadAllLines("./assets/players.csv")
                .Skip(1)
                .Select(x => x.Split(","))
                .Select(x => new Player()
                {
                    Lastname = x[1],
                    Gender = x[2]
                }).ToList());

        }
    }
}
