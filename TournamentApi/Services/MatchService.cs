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
        public Match SetWinner(int MatchId, int PlayerId)
        {
            Match match = db.Matches.Where(x => x.Id == MatchId).First();
            if (match != null)
            {
                if (PlayerId == match.Player1.Id)
                {
                    match.Winner = 1;
                    db.SaveChanges();
                    return match;
                }
                else if (PlayerId == match.Player2.Id)
                {
                    match.Winner = 2;
                    db.SaveChanges();
                    return match;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
        public List<Match> GenerateMatches()
        {
            int playerCount = db.Players.ToList().Count / 2;
            playerCount = playerCount * 2;
            var matchCount = db.Matches.ToList().Count;
            var rand = new Random();
            Console.WriteLine(db.Matches.ToList().Count);
            if (db.Matches.ToList().Count <= 0)
            {
                List<Match> matches = new List<Match>();
                List<Player> availablePlayers = db.Players.ToList();
                while (availablePlayers.Count > 0)
                {
                    var player1 = availablePlayers[rand.Next(availablePlayers.Count)];
                    availablePlayers.Remove(player1);
                    var player2 = availablePlayers[rand.Next(availablePlayers.Count)];
                    availablePlayers.Remove(player2);
                    matches.Add(new Match { Player1 = player1, Player2 = player2, RoundNumber = 1 });
                }
                db.Matches.AddRange(matches);
                db.SaveChanges();
                return matches;
            }
            else
            {
                List<Player> availablePlayers = new List<Player>();
                int roundNumber = db.Matches.OrderBy(x => x.RoundNumber).Last().RoundNumber;
                db.Matches.Where(x => x.RoundNumber == roundNumber).ToList().ForEach(x =>
                {
                    if (x.Winner == 1)
                    {
                        availablePlayers.Add(x.Player1);
                    }
                    else if (x.Winner == 2)
                    {
                        availablePlayers.Add(x.Player2);
                    }
                    else
                    {
                        throw new IndexOutOfRangeException();
                    }
                });
                if (matchCount % 2 == 0 && availablePlayers.Count < 1)
                {
                    List<Match> matches = new List<Match>();

                    while (availablePlayers.Count > 0)
                    {
                        var player1 = availablePlayers[rand.Next(availablePlayers.Count)];
                        availablePlayers.Remove(player1);
                        var player2 = availablePlayers[rand.Next(availablePlayers.Count)];
                        availablePlayers.Remove(player2);
                        matches.Add(new Match { Player1 = player1, Player2 = player2, RoundNumber = roundNumber+1 });
                    }
                    db.Matches.AddRange(matches);
                    db.SaveChanges();
                    return matches;
                }
                else
                {
                    throw new Exception();
                }
            }
        }
    }
}
