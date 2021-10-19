using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentDb;

namespace TournamentApi.Services
{
    public class PlayerService
    {
        private readonly TournamentContext db;
        public PlayerService(TournamentContext db)
        {
            this.db = db;
        }
        public List<Player> GetPlayers()
        {
            return db.Players.ToList();
        }
    }
}
