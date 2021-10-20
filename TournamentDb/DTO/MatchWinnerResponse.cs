using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentDb.DTO
{
    public class MatchWinnerResponse
    {
        public int Id { get; set; }
        public int RoundNumber { get; set; }
        public int Player1Id { get; set; }
        public int Player2Id { get; set; }
        public int? Winner { get; set; }
    }
}
