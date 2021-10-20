using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentDb;
using TournamentDb.DTO;

namespace TournamentApi.Services
{
    public class MatchService
    {
        private readonly TournamentContext _db;
        public MatchService(TournamentContext db)
        {
            this._db = db;

        }
        public Match SetWinner(MatchWinnerDto winnerDto)
        {
            Match match = _db.Matches.Where(x => x.Id == winnerDto.MatchId).FirstOrDefault();
            if (match != null)
            {
                if (winnerDto.PlayerId == match.Player1Id)
                {
                    match.Winner = 1;
                    _db.SaveChanges();
                    return _db.Matches.First(x => x.Id == winnerDto.MatchId);
                }
                else if (winnerDto.PlayerId == match.Player2Id)
                {
                    match.Winner = 2;
                    _db.SaveChanges();
                    return _db.Matches.First(x => x.Id == winnerDto.MatchId);
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
            var matchCount = _db.Matches.ToList().Count;
            var rand = new Random();
            Console.WriteLine(_db.Matches.ToList().Count);
            if (_db.Matches.ToList().Count <= 0)
            {
                List<Match> matches = new List<Match>();
                List<Player> availablePlayers = _db.Players.ToList();
                while (availablePlayers.Count > 1)
                {
                    var player1 = availablePlayers[rand.Next(availablePlayers.Count)];
                    availablePlayers.Remove(player1);
                    var player2 = availablePlayers[rand.Next(availablePlayers.Count)];
                    availablePlayers.Remove(player2);
                    matches.Add(new Match { Player1 = player1, Player2 = player2, RoundNumber = 1 });
                }
                _db.Matches.AddRange(matches);
                _db.SaveChanges();
                return matches;
            }
            else if (_db.Matches.Where(x => x.Winner == null).Any() == false)
            {
                Console.WriteLine("Get in here");
                List<Player> availablePlayers = new List<Player>();
                int roundNumber = _db.Matches.OrderBy(x => x.RoundNumber).Last().RoundNumber;
                _db.Matches.Where(x => x.RoundNumber == roundNumber).ToList().ForEach(x =>
                {
                    if (x.Winner == 1)
                    {
                        availablePlayers.Add(x.Player1);
                    }
                    else if (x.Winner == 2)
                    {
                        availablePlayers.Add(x.Player2);
                    }
                });
                if (matchCount % 2 == 0 && availablePlayers.Count < 1)
                {
                    Console.WriteLine("Get in here");
                    List<Match> matches = new List<Match>();

                    while (availablePlayers.Count > 0)
                    {
                        var player1 = availablePlayers[rand.Next(availablePlayers.Count)];
                        availablePlayers.Remove(player1);
                        var player2 = availablePlayers[rand.Next(availablePlayers.Count)];
                        availablePlayers.Remove(player2);
                        matches.Add(new Match { Player1 = player1, Player2 = player2, RoundNumber = roundNumber + 1 });
                    }
                    _db.Matches.AddRange(matches);
                    _db.SaveChanges();
                    return matches;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            else
            {
                Console.WriteLine("Throw ApplicationException");
                throw new ApplicationException();
            }

        }
        public List<Match> returnWithoutWinner()
        {
            return _db.Matches.Include(x => x.Player1).Include(x => x.Player2).Where(x => x.Winner == null).ToList();
        }
        public void DeleteAll()
        {
            _db.Matches.RemoveRange(_db.Matches);
            _db.SaveChanges();
            
        }


    }
}
