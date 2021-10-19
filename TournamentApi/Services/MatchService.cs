using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentDb;

namespace TournamentApi.Services
{
    public class MatchService
    {
        private readonly TournamentContext db;
        public MatchService(TournamentContext db)
        {
            this.db = db;
        }
    }
}
