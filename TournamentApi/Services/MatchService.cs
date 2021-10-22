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
                if (winnerDto.PlayerId == match.Player2Id)
                {
                    match.Winner = 2;
                    _db.SaveChanges();
                    return _db.Matches.First(x => x.Id == winnerDto.MatchId);
                }
                throw new IndexOutOfRangeException();
            }
            throw new ArgumentNullException();
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
                if (IsPowerOfTwo(availablePlayers.Count) == true)
                {
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
                throw new AggregateException();
            }
            else if (_db.Matches.Where(x => x.RoundNumber == _db.Matches.OrderBy(x => x.RoundNumber).Last().RoundNumber).ToList().Count == 1)
            {
                Console.WriteLine("Shouldnt be here because only 1 match remaining");

                throw new IndexOutOfRangeException();
            }
            else if (_db.Matches.Where(x => x.Winner == null).Any() == false)
            {
                List<Player> availablePlayers = new List<Player>();
                int roundNumber = _db.Matches.OrderBy(x => x.RoundNumber).Last().RoundNumber;
                _db.Matches
                    .Where(x => x.RoundNumber == roundNumber)
                    .Include(x => x.Player1).Include(x => x.Player2)
                    .ToList()
                    .ForEach(x =>
                        availablePlayers.Add(x.Winner == 1 ? x.Player1 : x.Player2)
                     );
                Console.WriteLine(availablePlayers[1].Firstname);
                if (matchCount % 2 == 0 && availablePlayers.Count > 1)
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

        public List<Match> returnCurrentRound()
        {
            return _db.Matches.Include(x => x.Player1).Include(x => x.Player2).Where(x => x.RoundNumber == _db.Matches.OrderBy(x => x.RoundNumber).Last().RoundNumber).ToList();
        }

        public List<Match> AllMatches()
        {
            return _db.Matches.ToList();
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
        private bool IsPowerOfTwo(int x)
        {
            return (x != 0) && ((x & (x - 1)) == 0);
        }


    }
}
