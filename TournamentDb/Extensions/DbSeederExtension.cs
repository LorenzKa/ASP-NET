using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentDb.Extensions
{
    public static class DbSeederExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            List<Player> players = File.ReadAllLines("../TournamentDb/assets/players.csv")
                .Skip(1)
                .Select(x => x.Split(","))
                .Select(x => new Player()
                {
                    Firstname = x[0],
                    Lastname = x[1],
                    Gender = x[2]
                }).ToList();
            for (int i = 0; i < players.Count; i++)
            {
                players[i].Id = i + 1;
                modelBuilder.Entity<Player>().HasData(players[i]);
            }
            

        }
    }
}
