using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentDb.DTO
{
    public class MatchWinnerResponse
    {
        public int MatchId { get; set; }
        public int Winner { get; set; }
    }
}
