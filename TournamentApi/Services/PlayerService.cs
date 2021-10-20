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
        private readonly TournamentContext _db;
        public PlayerService(TournamentContext db)
        {
            this._db = db;
        }
        public List<Player> GetPlayers()
        {
            return _db.Players.ToList();
        }
    }
}
