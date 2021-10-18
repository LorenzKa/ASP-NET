using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentDb
{
    public class TournamentService
    {
        private readonly TournamentContext db;

        public TournamentService(TournamentContext db)
        {
            this.db = db;
        }
    }
}
