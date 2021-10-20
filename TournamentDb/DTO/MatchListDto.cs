using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentDb.DTO
{
    public class MatchListDto
    {
        public int RoundNumber { get; set; }
        public List<MatchDto> Matches { get; set; }
    }
}
